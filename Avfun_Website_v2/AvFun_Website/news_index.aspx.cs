using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvFun_Website
{
    public partial class news_index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NewsIndexDataSource_Filtering(object sender, SqlDataSourceFilteringEventArgs e)
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
            if (dplstSearchScope.SelectedValue.ToString().Equals("All"))
            {
                //全部搜索，简单刷新下就行
                Response.Redirect(Request.Url.ToString());
            }
        }

    }
}