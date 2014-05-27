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
    public partial class admin_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAdminBLL adminBLL = BLLFactory.CreateInstance<IAdminBLL>("AdminBLL");
            Admin loggedAdmin = adminBLL.isLogged(Request);
            if (!Page.IsPostBack)
            {
                //第一次显示
                if (loggedAdmin != null) //已经登录
                {
                    //如果已经登录
                    AdminLoginForm.Visible = false; //不显示登录页面
                    AdminLoginStatus.Text = "欢迎回来！尊敬的管理员" + loggedAdmin.User_nickname + "，3秒后自动为您转入管理员首页";
                    AdminLoginStatus.Visible = true;
                    //重定向
                    HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                    RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                    RedirectMeta.Content = "3;url=admin_index.aspx"; //时间为三秒，跳转到首页
                    this.Page.Header.Controls.Add(RedirectMeta);
                }
                else //没登录
                {
                    AdminLoginForm.Visible = true;
                    AdminLoginStatus.Visible = false; //隐藏指示信息
                }
            }
            else
            {
                //提交回来了登录信息
                String AdminLoginVerifyCode = Request.Form["txtAdminVerifyCode"];
                String adminAccount = Request.Form["txtAdminAccount"];
                String adminPassword = Request.Form["txtAdminPassword"];
                if (Session[AdminLoginVerifyCodeGenerator.strIdentify] != null &&
                     !Session[AdminLoginVerifyCodeGenerator.strIdentify].ToString().Equals("") && //notNullAndEmpty
                     AdminLoginVerifyCode != null &&
                    !AdminLoginVerifyCode.Equals(""))
                {
                    //清空Session防止后退提交
                    Session.Remove(AdminLoginVerifyCodeGenerator.strIdentify);

                    //验证码校验通过
                    Admin loginAdmin = new Admin();
                    loginAdmin.User_account = adminAccount;
                    loginAdmin.User_password = adminBLL.MD5(adminPassword);
                    Admin entireAdmin = adminBLL.isLegalLogin(loginAdmin);
                    if (entireAdmin != null )
                    {
                        //合法登录请求
                        entireAdmin.User_last_login_date = DateTime.Now; //登录时间
                        entireAdmin.User_last_login_ip = HttpContext.Current.Request.UserHostAddress; //登录ip
                        adminBLL.UpdateAdminInfo(entireAdmin); //更新登录ip和时间
                        //分配cookies
                        HttpCookie adminAccountCookie = new HttpCookie("adminAccount");
                        HttpCookie adminPasswordCookie = new HttpCookie("adminPassword");
                        adminAccountCookie.Value = entireAdmin.User_account;
                        adminPasswordCookie.Value = entireAdmin.User_password;
                        adminAccountCookie.Expires = DateTime.Now.AddDays(1D); // 1天过期
                        adminPasswordCookie.Expires = DateTime.Now.AddDays(1D); //1天过期
                        //添加Cookie，相当于授权
                        Response.Cookies.Add(adminAccountCookie);
                        Response.Cookies.Add(adminPasswordCookie);

                        //UI操作
                        AdminLoginForm.Visible = false; //不显示登录页面
                        AdminLoginStatus.Text = "欢迎回来！尊敬的管理员" + entireAdmin.User_nickname + "，3秒后自动为您转入管理员首页";
                        AdminLoginStatus.Visible = true;
                        //重定向
                        HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                        RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                        RedirectMeta.Content = "3;url=admin_index.aspx"; //时间为三秒，跳转到首页
                        this.Page.Header.Controls.Add(RedirectMeta);

                    }
                    else
                    {
                        //登录请求非法
                        AdminLoginStatus.Text = "用户名或密码错误，请重试";
                        AdminLoginStatus.Visible = true;
                        AdminLoginForm.Visible = true;
                    }
                }
                else
                {
                    //验证码校验失败，给出提示信息
                    AdminLoginStatus.Text = "验证码校验失败，请刷新验证码后重试";
                    AdminLoginStatus.Visible = true;
                    AdminLoginForm.Visible = true;
                }
            }
        }
    }
}