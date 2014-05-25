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
    public partial class course_manage_index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Admin loggedAdmin = AdminOpr.isLogged(Request);
            if (loggedAdmin == null)
            {
                //没登录
                LoginForm.Visible = false;
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (dplstSearchScope.SelectedValue.Equals("all"))
            {
                //搜索全部的话，简单刷新即可。
                Response.Redirect(Request.Url.ToString());
            }
            else
            {

                if (dplstSearchScope.SelectedValue.Equals("alreadyBuy"))
                {
                    BoundField buyCoursePeople = new BoundField();
                    buyCoursePeople.DataField = "course_people";
                    buyCoursePeople.DataFormatString = "{0}";
                    buyCoursePeople.HeaderText = "购买人数";
                    //魔法！别动！
                    CourseManageDataSource.SelectCommand
                        =
    "SELECT [avfun].[dbo].[COURSE].[course_id],[avfun].[dbo].[COURSE].[course_name],[avfun].[dbo].[COURSE].[course_price],[avfun].[dbo].[COURSE].[course_robot_link],[avfun].[dbo].[COURSE].[course_begin_date],[avfun].[dbo].[COURSE].[course_isDeleted],[avfun].[dbo].[COURSE].[course_timestamp],count([user_id]) as course_people"
    + " FROM [avfun].[dbo].[COURSE],[avfun].[dbo].[UserCourseList]"
    + "  WHERE([avfun].[dbo].[COURSE].[course_id] = order_course )"
    + "  GROUP BY [avfun].[dbo].[COURSE].[course_id],[avfun].[dbo].[COURSE].[course_name],[avfun].[dbo].[COURSE].[course_price],[avfun].[dbo].[COURSE].[course_robot_link],[avfun].[dbo].[COURSE].[course_begin_date],[avfun].[dbo].[COURSE].[course_isDeleted],[avfun].[dbo].[COURSE].[course_timestamp]"
    + "  ORDER BY [avfun].[dbo].[COURSE].[course_begin_date] DESC";
                    CourseLists.Columns.Add(buyCoursePeople);

                }
                else
                {
                    CourseLists.Columns.RemoveAt(CourseLists.Columns.Count - 1);
                    CourseManageDataSource.SelectCommand = "SELECT [course_id], [course_name], [course_price], [course_begin_date], [course_robot_link], [course_isDeleted] FROM [COURSE] ORDER BY [course_begin_date] DESC";
                }
            }
        }

        protected void CourseManageDataSource_Filtering(object sender, SqlDataSourceFilteringEventArgs e)
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