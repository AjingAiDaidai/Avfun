using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Avfun_UI;
using Avfun_BLL;
namespace AvFun_Website.admin
{
    public partial class AddCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ICourseBLL courseBLL = BLLFactory.CreateInstance<ICourseBLL>("CourseBLL");
            IAdminBLL adminBLL = BLLFactory.CreateInstance<IAdminBLL>("AdminBLL");
            Admin loggedAdmin = adminBLL.isLogged(Request);
            if (loggedAdmin == null)
            {
                //没登录
                LoginForm.Visible = false;
                lblLoginStatus.Visible = true;
                lblLoginStatus.Text = "您未登录或登录已经过期，请重新登录";
            }
            else
            {
                //已经登录
                if (!Page.IsPostBack)
                {
                    //没提交回来
                    if (Request.QueryString["course_id"] != null)
                    {
                        //修改课程信息
                        Course toFindCourse = new Course();
                        toFindCourse.Course_id = new Guid(Request.QueryString["course_id"].ToString());
                        Course entireCourse = courseBLL.GetCourseByID(toFindCourse);
                        if (entireCourse != null)
                        {
                            //找到了
                            txtCourseIntro.Text = entireCourse.Course_intro;
                            txtCoursePrice.Text = entireCourse.Course_price.ToString();
                            txtCourseTitle.Text = entireCourse.Course_name;
                            txtCourseRobotLink.Text = entireCourse.Course_robot_link;
                        }
                        else
                        {
                            //没找到
                            lblLoginStatus.Text = "试图修改的课程不存在";
                            lblLoginStatus.Visible = true;
                            LoginForm.Visible = false;
                        }
                    }
                }
                else
                {
                    //被提交回来惹！
                    if (Request.QueryString["course_id"] == null)
                    {
                        //填充新课程信息
                        Guid course_id = System.Guid.NewGuid();
                        String course_name = Request.Form[txtCourseTitle.ID];
                        DateTime course_begin_date = DateTime.Now;
                        Double course_price = Convert.ToDouble(Request.Form[txtCoursePrice.ID]);
                        String course_robot_link = Request.Form[txtCourseRobotLink.ID];
                        Boolean course_is_deleted = false;
                        String course_intro = Request.Form[txtCourseIntro.ID];
                        //OK，开始赋值
                        Course newCourse = new Course();
                        newCourse.Course_id = course_id;
                        newCourse.Course_name = course_name;
                        newCourse.Course_begin_date = course_begin_date;
                        newCourse.Course_price = course_price;
                        newCourse.Course_robot_link = course_robot_link;
                        newCourse.Course_intro = course_intro;
                        newCourse.Course_isDeleted = course_is_deleted;
                        if (courseBLL.CreateCourse(newCourse))
                        {
                            lblLoginStatus.Text = "发布课程成功";
                            lblLoginStatus.Visible = true;
                        }
                        else
                        {
                            lblLoginStatus.Text = "发布课程失败";
                            lblLoginStatus.Visible = true;
                        }
                    }
                    else
                    {
                        //修改课程信息
                        Course toFindCourse = new Course();
                        toFindCourse.Course_id = new Guid(Request.QueryString["course_id"].ToString());
                        Course entireCourse = courseBLL.GetCourseByID(toFindCourse);
                        if (entireCourse != null)
                        {
                            //找到了
                            String course_name = Request.Form[txtCourseTitle.ID];
                            Double course_price = Convert.ToDouble(Request.Form[txtCoursePrice.ID]);
                            String course_robot_link = Request.Form[txtCourseRobotLink.ID].Trim();
                            String course_intro = Request.Form[txtCourseIntro.ID];
                            //赋值
                            entireCourse.Course_name = course_name;
                            entireCourse.Course_price = course_price;
                            entireCourse.Course_robot_link = course_robot_link;
                            entireCourse.Course_intro = course_intro;
                            if (courseBLL.UpdateCourseInfo(entireCourse))
                            {
                                lblLoginStatus.Text = "修改课程信息成功";
                                lblLoginStatus.Visible = true;
                            }
                            else
                            {
                                lblLoginStatus.Text = "修改课程信息失败";
                                lblLoginStatus.Visible = true;
                            }
                        }
                        else
                        {
                            //没找到
                            lblLoginStatus.Text = "试图修改的课程不存在";
                            lblLoginStatus.Visible = true;
                            LoginForm.Visible = false;
                        }
                    }

                }
            }
        }
    }
}