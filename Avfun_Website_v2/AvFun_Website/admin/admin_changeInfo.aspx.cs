using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Avfun_BLL;
using Avfun_UI;
namespace AvFun_Website.admin
{
    public partial class admin_changeInfo : System.Web.UI.Page
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
                LoggedForm.Visible = false;
                //重定向
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=admin_login.aspx"; //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
            else
            {
                //已登录
                if (!Page.IsPostBack)
                {
                    //首次访问
                    lblLoginStatus.Visible = false;
                    LoggedForm.Visible = true;
                    txtAdminNickname.Text = loggedAdmin.User_nickname.Trim();
                }
                else
                {
                    //提交修改信息
                    String adminOldPassword = Request.Form[txtOldPassword.ID];
                    String adminNewPassword = Request.Form[txtNewPassword.ID];
                    String adminVerifyNewPassword = Request.Form[txtVerifyNewPassword.ID];
                    String adminNickname = Request.Form[txtAdminNickname.ID].Trim();
                   
                    //修改密码的验证，填写了旧密码，要修改密码
                    if (!adminOldPassword.Equals("")
                        && adminOldPassword != null
                        )
                    {
                        //长度验证
                        if (adminOldPassword.Length < 6
                            || adminOldPassword.Length > 16
                            || !adminBLL.MD5(adminOldPassword).Equals(loggedAdmin.User_password)
                            )
                        { //长度不对或输入不符
                            lblChangeInfo.Text = "旧密码输入错误或旧密码格式不正确，旧密码长度应在6-16位之间，请重试";
                            lblChangeInfo.Visible = true;
                        }
                        else
                        {
                            //新密码一致性检查
                            if (adminNewPassword.Equals("")
                                || adminNewPassword == null
                                || adminNewPassword.Length < 6
                                || adminNewPassword.Length > 16
                                || !adminNewPassword.Equals(adminVerifyNewPassword))
                            {
                                lblChangeInfo.Text = "新密码与确认密码不一致或长度不正确（应在6-16位之间），请重试";
                            }
                            else
                            {
                                //新密码一致性检查通过，赋值赋值赋值。
                         
                                loggedAdmin.User_password = adminBLL.MD5(adminNewPassword);
                                loggedAdmin.User_nickname = adminNickname;
                                if (adminBLL.UpdateAdminInfo(loggedAdmin))
                                {
                                    //修改成功
                                    lblLoginStatus.Text = "您已成功修改密码，请重新登录，3秒后跳转到登录页面";
                                    LoggedForm.Visible = false;
                                    lblLoginStatus.Visible = true;

                                    //跳转
                                    HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                                    RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                                    RedirectMeta.Content = "3;url=admin_login.aspx"; //时间为三秒，跳转到首页
                                    this.Page.Header.Controls.Add(RedirectMeta);

                                }
                                else
                                {
                                    //修改失败
                                    lblLoginStatus.Text = "修改密码失败，请检查输入项";
                                    lblLoginStatus.Visible = true;
                                    LoggedForm.Visible = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        //没填旧密码，修改其他信息
                        loggedAdmin.User_nickname = adminNickname;
                        if (adminBLL.UpdateAdminInfo(loggedAdmin))
                        {
                            lblLoginStatus.Text = "您已成功修改信息";
                            LoggedForm.Visible = true;
                            lblLoginStatus.Visible = true;
                        }
                        else
                        {
                            lblLoginStatus.Text = "修改信息失败，原因可能是服务器大姨妈或您的输入有误，请重试";
                            LoggedForm.Visible = true;
                            lblLoginStatus.Visible = true;
                        }
                    }

                }
            }
        }
    }
}