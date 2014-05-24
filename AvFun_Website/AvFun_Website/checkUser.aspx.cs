using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using AvFun_Website.Avfun_BLL;
using AvFun_Website.AvFun_UI;

namespace AvFun_Website
{
    public partial class checkUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User loggedUser = UserOpr.isLogged(Request);
            if (loggedUser == null)
            {
                //未登录
                CheckUserForm.Visible = false;
                lblLoginStatus.Text = "您未登录或者已经登录过期，请登录后再进行激活。3秒后转向登录页面";
                lblLoginStatus.Visible = true;

                //重定向
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=" + ReadWebConfig.GetAppSettingValue("LoginPageURL"); //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
            if (loggedUser.User_isChecked)
            {
                //已经激活
                lblLoginStatus.Text = "您已经是激活用户，无需再次激活";
                lblLoginStatus.Visible = true;
            }
            else
            {
                lblLoginStatus.Visible = false;
                //获取Guid
                if (Request.QueryString["VerifyCode"] != null)
                {
                    try
                    {
                        //这里有可能出错所以要用try...catch
                        Guid userVerifyCode = new Guid(Request.QueryString["VerifyCode"]);
                        if (UserOpr.CheckUser(loggedUser, userVerifyCode))
                        {
                            //验证通过
                            lblCheckStatus.Text = "恭喜您，验证成功";
                            lblCheckStatus.Visible = true;
                        }
                        else
                        {
                            lblCheckStatus.Text = "验证码不符，请尝试重发确认信";
                            lblCheckStatus.Visible = true;
                        }

                    }
                    catch
                    {
                        lblCheckStatus.Text = "验证码格式不正确";
                        lblCheckStatus.Visible = true;
                    }
                }
                else
                {
                    lblCheckStatus.Text = "验证码不可以为空";
                    lblCheckStatus.Visible = true;
                }
            }
        }
    }
}