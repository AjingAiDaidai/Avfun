using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Avfun_UI;
using Avfun_BLL;
namespace AvFun_Website
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUserBLL userBLL = BLLFactory.CreateInstance<IUserBLL>("UserBLL");
            //每1分钟才能发一次找回密码请求
            Session.Timeout = 1;
            if (!Page.IsPostBack)
            {
                //第一次访问页面
                ForgetPasswordForm.Visible = true; //找回密码窗体可见
                ForgetPswInfo.Text = "请输入注册邮箱："; //重设提示信息
                ForgetPswInfo.Visible = true; //提示信息可见
            }
            else
            {
                //用户提交
                User forgetUser = new User();
                String userAccount = Request.Form["UserAccount"].Trim();
                forgetUser.User_account = userAccount;
                //防止email轰炸
                if (Session[forgetUser.User_account] == null)
                {
                    if (userBLL.GetForgetPassword(forgetUser))
                    {
                        //成功取回密码
                        ForgetPswInfo.Text = "取回密码成功！请进入您的注册邮箱查收密码，3秒后跳转到主页";
                        //重定向
                        HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                        RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                        RedirectMeta.Content = "3;url=" + ReadWebConfig.GetAppSettingValue("Domain"); //时间为三秒，跳转到首页
                        this.Page.Header.Controls.Add(RedirectMeta);

                        //分配Session避免邮箱轰炸
                        Session.Add(forgetUser.User_account, DateTime.Now.ToString());

                        //UI操作
                        ForgetPasswordForm.Visible = false; //取回密码窗体不可见
                        ForgetPswInfo.Visible = true;
                    }
                    else
                    {
                        ForgetPswInfo.Text = "取回密码失败，请检查输入的账户是否正确";
                        ForgetPasswordForm.Visible = true;
                        ForgetPswInfo.Visible = true;
                    }
                }
                else
                {
                    //给出误导信息，实际上一分钟就行，防止黑客利用
                    ForgetPswInfo.Text = "您的操作过于频繁，请3分钟后再试";
                    ForgetPasswordForm.Visible = true;
                    ForgetPswInfo.Visible = true;
                }

            }
        }
    }
}