using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Avfun_UI;
using Avfun_BLL;
namespace AvFun_Website.user_pages
{
    public partial class user_course_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUserBLL userBLL = BLLFactory.CreateInstance<IUserBLL>("UserBLL");
            User loggedUser = userBLL.isLogged(Request);
            if (loggedUser == null)
            {
                //未登录
                LoginStatus.Text = "主人大人，您未登录或已经登录过期哦！3秒后自动转向登录页面哦！请登录了再来调戏人家啦";
                LoginStatus.Visible = true; //提示信息开启
                UserCourseListForm.Visible = false;
                //重定向
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=" + ReadWebConfig.GetAppSettingValue("LoginPageURL"); //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
            else
            {
                //登录后
                //给个值
                CourseListDataSource.SelectParameters["user_id"].DefaultValue = loggedUser.User_id.ToString();
            }
        }

        protected void CourseListDataSource_Filtering(object sender, SqlDataSourceFilteringEventArgs e)
        {
            if (e.ParameterValues[0].ToString().Equals("all") )
            {
                e.ParameterValues[0] = null;
                return;
            }
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
            if (dplstSearchScope.SelectedValue.ToString().Equals("all"))
            {
                //全部搜索，简单刷新下就行
                Response.Redirect(Request.Url.ToString());
            }
        }
    }
}