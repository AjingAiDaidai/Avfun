using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using AvFun_Website.AvFun_UI;
using AvFun_Website.Avfun_BLL;

namespace AvFun_Website.admin
{
    public partial class admin_statistical : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Admin loginAdmin = AdminOpr.isLogged(Request);
            if (loginAdmin == null)
            {
                //未登录
                lblLoginStatus.Text = "您未登录或已经登录过期，请重新登录，3秒后转回管理员登录页。";
                lblLoginStatus.Visible = true;
                StatisticalForm.Visible = false;
                //重定向
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=admin_login.aspx"; //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
        }

        protected void AdminStatisticDataSource_Filtering(object sender, SqlDataSourceFilteringEventArgs e)
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
    }
}