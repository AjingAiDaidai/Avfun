using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Avfun_UI;
using Avfun_BLL;
namespace AvFun_Website.admin
{
    public partial class admin_index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAdminBLL adminBLL = BLLFactory.CreateInstance<IAdminBLL>("AdminBLL");
            Admin loggedAdmin = adminBLL.isLogged(Request);
            if (loggedAdmin == null)
            {
                //未登录
                lblLoginStatus.Text = "您未登录或已经登录过期，请重新登录，3秒后转回管理员登录页。";
                lblLoginStatus.Visible = true;
                AdminLoggedForm.Visible = false;
                //重定向
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=admin_login.aspx"; //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
            else
            {
                //已经登录
                if (!Page.IsPostBack)
                {
                    //未点击登出按钮
                    lblAdminInfo.Text = "尊敬的管理员：" + loggedAdmin.User_nickname + "您好";
                    lblShortInfo.Text =
                        "您最后一次登录时间是" + loggedAdmin.User_last_login_date.ToString()
                        + "，最后一次登录IP为" + loggedAdmin.User_last_login_ip;
                    lblAdminInfo.Visible = true;
                    AdminLoggedForm.Visible = true;
                    lblLoginStatus.Visible = false;
                }
                else
                {
                    //点击登出
                   //删除admin cookie
                   HttpCookie userAccountCookie = new HttpCookie("adminAccount");
                   userAccountCookie.Expires = DateTime.Now.AddDays(-1D);
                   Response.Cookies.Add(userAccountCookie);
                   //删除password cookie
                   HttpCookie userPasswordCookie = new HttpCookie("adminPassword");
                   userPasswordCookie.Expires = DateTime.Now.AddDays(-1D);
                   Response.Cookies.Add(userPasswordCookie);
                   //给出提示信息，转回主页
                   lblLoginStatus.Text = "您已经成功登出，3秒后转回站点主页";
                   AdminLoggedForm.Visible = false;
                   lblLoginStatus.Visible = true;
                   //重定向
                   HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                   RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                   RedirectMeta.Content = "3;url=" + ReadWebConfig.GetAppSettingValue("Domain"); //时间为三秒，跳转到首页
                   this.Page.Header.Controls.Add(RedirectMeta);
                }
            }
        }
    }
}