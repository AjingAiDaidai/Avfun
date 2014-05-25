using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using AvFun_Website.Avfun_BLL;
using AvFun_Website.AvFun_UI;
namespace AvFun_Website.admin
{
    public partial class DelUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Admin loggedAdmin = AdminOpr.isLogged(Request);
            if (loggedAdmin == null)
            {
                lblLoginStatus.Text = "您未登录或已登录过期，请重新登录。3秒后转向登录页面";
                lblLoginStatus.Visible = true;
                //重定向
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=admin_login.aspx"; //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
            else
            {
                try
                {
                    User toDelUser = new User();
                    //这里有可能出错要用try...catch
                    Guid userID = new Guid(Request.QueryString["user_id"]);
                    toDelUser.User_id = userID;
                    User entireUser = UserOpr.GetUserByID(toDelUser);
                    if (entireUser != null)
                    {
                        //找到了
                        //删除
                        entireUser.User_isDeleted = true;
                        if (UserOpr.UpdateUserInfo(entireUser))
                        {
                            lblLoginStatus.Text = "删除用户成功";
                            lblLoginStatus.Visible = true;
                        }
                        else
                        {
                            lblLoginStatus.Text = "删除用户失败";
                            lblLoginStatus.Visible = true;
                        }
                    }
                    else
                    {
                        lblLoginStatus.Text = "没有这个用户";
                        lblLoginStatus.Visible = true;
                    }
                }
                catch
                {
                    lblLoginStatus.Text = "用户ID格式不正确";
                    lblLoginStatus.Visible = true;
                }
                
            }
        }
    }
}