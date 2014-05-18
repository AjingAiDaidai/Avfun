using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using AvFun_Website.AvFun_UI;
using AvFun_Website.Avfun_BLL;

namespace AvFun_Website.user_pages
{
    public partial class user_changeinfo : System.Web.UI.Page
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

            }
        }
    }
}