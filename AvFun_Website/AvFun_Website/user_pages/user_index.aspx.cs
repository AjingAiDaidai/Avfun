using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using AvFun_Website.AvFun_UI;
using AvFun_Website.Avfun_BLL;
namespace AvFun_Website.user_pages
{
    public partial class user_index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断是否已经登录
            User loggedUser = UserOpr.isLogged(Request);
            //未登录 
            if (loggedUser == null)
            {
                //登录界面不显示
                loggedDiv.Visible = false;
                //提示信息
                logStatus.Text = "主人大人，您未登录或已经登录过期哦！3秒后自动转向登录页面哦！请登录了再来调戏人家啦";
                logStatus.Visible = true; //提示信息开启

                //重定向
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=" + ReadWebConfig.GetAppSettingValue("LoginPageURL"); //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
            else //已登录 
            {
                if (!Page.IsPostBack)
                {
                    //第一次访问，在这里读取数据减轻服务器压力
                    //读取用户信息
                    nickName.Text = loggedUser.User_nickname;
                    head.ImageUrl = loggedUser.User_head.Trim(); //这里不取Domain是为了在以后上传的时候保持一致
                    last_login_time.Text = loggedUser.User_last_login_date.ToString("yyyy年MM月dd日"); //本地日期保持一致
                    last_login_ip.Text = loggedUser.User_last_login_ip;
                    money.Text = loggedUser.User_money.ToString();
                    //判断是否激活
                    if ( loggedUser.User_isChecked )
                        isChecked.Text = "已激活";
                    else
                        isChecked.Text = "未激活";
                    //判断是否被删除
                    if ( loggedUser.User_isDeleted )
                        isDeleted.Text = "已被冻结";
                    else
                        isDeleted.Text = "未被冻结";

                    user_introduction.Text = loggedUser.User_introduction; //用户介绍
                }
            }

        }
    }
}