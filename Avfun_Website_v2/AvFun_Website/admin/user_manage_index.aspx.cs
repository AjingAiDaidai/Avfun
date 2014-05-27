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
    public partial class user_manage_index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAdminBLL adminBLL = BLLFactory.CreateInstance<IAdminBLL>("AdminBLL");
            Admin loggedAdmin = adminBLL.isLogged(Request);
            if (loggedAdmin == null)
            {
                //没登录

                UserManageForm.Visible = false;
                lblLoginStatus.Visible = true;
                lblLoginStatus.Text = "您未登录或登录已经过期，请重新登录。3秒后跳转到登录页面";
                //重定向
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=admin_login.aspx"; //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
            else
            {
                //已经登录
            }
        }

        protected void UserDataSource_Filtering(object sender, SqlDataSourceFilteringEventArgs e)
        {
            if (e.ParameterValues[1] != null)
            {
                //防注入，替换四个关键key
                // e.ParameterValues[1].ToString().Replace("'", "''");
                e.ParameterValues[1] = e.ParameterValues[1].ToString().Replace("'", "''");
                e.ParameterValues[1] = e.ParameterValues[1].ToString().Replace("[", "[[]");
                e.ParameterValues[1] = e.ParameterValues[1].ToString().Replace("%", "[%]");
                e.ParameterValues[1] = e.ParameterValues[1].ToString().Replace("_", "[_]");
                /*
                AdminNewsListDataSource.FilterExpression.Replace("{1}", e.ParameterValues[1].ToString().Replace("[", "[[]"));
                AdminNewsListDataSource.FilterExpression.Replace("{1}", e.ParameterValues[1].ToString().Replace("%", "[%]"));
                AdminNewsListDataSource.FilterExpression.Replace("{1}", e.ParameterValues[1].ToString().Replace("_", "[_]"));
                */
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (dplstSearchScope.SelectedValue == null )
            {
                //搜索全部的话，简单刷新即可。
                Response.Redirect(Request.Url.ToString());
            }
        }
    }
}