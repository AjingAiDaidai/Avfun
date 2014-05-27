using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Avfun_UI;
using Avfun_BLL;
namespace AvFun_Website.user_pages
{
    public partial class ResendVerifyMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUserBLL userBLL = BLLFactory.CreateInstance<IUserBLL>("UserBLL");
            User loggedUser = userBLL.isLogged(Request);
            if (loggedUser == null)
            {
                LoginStatus.Text = "您未登录或登录过期，请重新登录，3秒后跳转到用户登录页面";
                LoginStatus.Visible = true;
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=" + ReadWebConfig.GetAppSettingValue("LoginPageURL"); //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    if (loggedUser.User_isChecked)
                    {
                        //已激活
                        LoginStatus.Text = "您已经完成用户激活，无需再次激活";
                        LoginStatus.Visible = true;
                    }
                    else
                    {
                        //未激活
                        userBLL.SendVerifyMailToNewUser(loggedUser);
                        LoginStatus.Text = "确认信已经发往您登录时所用邮箱，请查收";
                        LoginStatus.Visible = true;
                    }
                }
            }
        }
    }
}