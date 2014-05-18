using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using AvFun_Website.AvFun_UI;
using AvFun_Website.Avfun_BLL;
namespace AvFun_Website
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //第一次访问
                LoginForm.Visible = true;
            }
            else
            {
                //提交回来了，校验。
                String userAccount = Request.Form["UserAccount"].Trim();
                String userPassword = Request.Form["UserPassword"];
                String loginVerifyCode = Request.Form["LoginVerifyCode"];

                //先校验验证码
                if (
                    Session[LoginVerifyCodeGenerator.strIdentify] != null 
                    && Session[LoginVerifyCodeGenerator.strIdentify].ToString().ToUpper().Equals
                         (loginVerifyCode.ToUpper()     )
                    && !loginVerifyCode.Equals("")
                    && loginVerifyCode != null
                     //以上三行防止后退提交用的
                   )
                {
                    Session.Remove(LoginVerifyCodeGenerator.strIdentify); //防止后退提交
                    //验证码校验通过，设定要取回的User的账号密码
                    User verifyUser = new User();
                    verifyUser.User_account = userAccount;
                    verifyUser.User_password = UserOpr.MD5(userPassword);
                    //验证用户是否是合法登录请求
                    User entireUser = UserOpr.isLegalLogin(verifyUser);
                    if (entireUser == null) //账号或密码错误，未注册，都是这个
                    {
                        LoginInfo.Text = "账号或密码错误";
                        LoginForm.Visible = true;
                    }
                    else
                    {
                        //登录成功，更改提示信息，更新登录信息中的IP和日期，这里记得换成UpdateUserInfo！

                        entireUser.User_last_login_date = DateTime.Now; //获取当前登录日期
                        entireUser.User_last_login_ip = HttpContext.Current.Request.UserHostAddress; //最后一次登录ip
                        UserOpr.UpdateUserInfo(entireUser);
                        LoginInfo.Text = "登录成功！3秒后跳转回主页";
                        //授予Cookies，相当于授权了

                        HttpCookie userAccountCookie = new HttpCookie("userAccount");
                        HttpCookie userPasswordCookie = new HttpCookie("userPassword");
                        userAccountCookie.Value = verifyUser.User_account;
                        userPasswordCookie.Value = verifyUser.User_password;

                        if (RememberMe.Checked) //这个判断很诡异，貌似Request.Form不好用的样子。
                        {
                            //如果选了RememberMe就保留一个星期
                            userPasswordCookie.Expires = DateTime.Now.AddDays(7D);
                            userAccountCookie.Expires = DateTime.Now.AddDays(7D);
                        }
                        //添加Cookie，相当于授权
                        Response.Cookies.Add(userAccountCookie);
                        Response.Cookies.Add(userPasswordCookie);
                        //重定向
                        HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                        RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                        RedirectMeta.Content = "3;url=" + ReadWebConfig.GetAppSettingValue("Domain"); //时间为三秒，跳转到首页
                        this.Page.Header.Controls.Add(RedirectMeta);
                        //UI操作
                        LoginForm.Visible = false;
                    }
                }
                else
                { 
                    //验证码校验失败
                    LoginInfo.Text = "验证码输入错误，请检查";
                    LoginForm.Visible = true;
                }

            }
        }
    }
}