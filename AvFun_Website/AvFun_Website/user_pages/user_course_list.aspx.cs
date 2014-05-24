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
    public partial class user_course_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User loggedUser = UserOpr.isLogged(Request);
            if (loggedUser == null)
            {
                //未登录
                LoginStatus.Text = "主人大人，您未登录或已经登录过期哦！3秒后自动转向登录页面哦！请登录了再来调戏人家啦";
                LoginStatus.Visible = true; //提示信息开启
                UserCourseListForm.Visible = false;
                //重定向
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=" + ReadWebConfig.GetAppSettingValue("LoginPageURL"); //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
            else
            {
                //登录后
                //给个值
                CourseListDataSource.SelectParameters["user_id"].DefaultValue = loggedUser.User_id.ToString();
            }
        }
    }
}