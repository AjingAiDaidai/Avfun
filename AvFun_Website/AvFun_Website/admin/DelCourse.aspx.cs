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
    public partial class DelCourse : System.Web.UI.Page
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
                //已登录
                if (Request.QueryString["course_id"] == null)
                {
                    //id没有
                    lblLoginStatus.Text = "试图删除的课程不存在";
                    lblLoginStatus.Visible = true;
                }
                else
                {
                    //有了id
                    String course_id = Request.QueryString["course_id"];
                    Course toDelCourse = new Course();
                    toDelCourse.Course_id = new Guid(course_id);
                    Course entireCourse = CourseOpr.GetCourseByID(toDelCourse);
                    if (entireCourse != null)
                    {
                        //获取到了course信息
                        entireCourse.Course_isDeleted = true;
                        if (CourseOpr.UpdateCourseInfo(entireCourse))
                        {
                            lblLoginStatus.Text = "删除课程成功";
                            lblLoginStatus.Visible = true;
                        }
                        else
                        {
                            lblLoginStatus.Text = "删除课程失败";
                            lblLoginStatus.Visible = true;
                        }
                    }
                    else
                    {
                        lblLoginStatus.Text = "试图删除的课程不存在";
                        lblLoginStatus.Visible = true;
                    }
                }
            }
        }
    }
}