using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using AvFun_Website.Avfun_BLL;
using AvFun_Website.AvFun_UI;
namespace AvFun_Website
{
    public partial class BuyCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User loggedUser = UserOpr.isLogged(Request);
            if (loggedUser == null) //如果未登录
            {
                BuyCourseForm.Visible = false;
                lblLoginStatus.Text = "您未登录或已登录过期，请登录后再进行召唤。3秒后跳转到用户登录界面";
                //重定向
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=" + ReadWebConfig.GetAppSettingValue("LoginPageURL"); //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
            else
            {
                if (loggedUser.User_isChecked == false
                    || loggedUser.User_isDeleted == true
                    )
                {
                    BuyCourseForm.Visible = false;
                    lblLoginStatus.Text = "您的账户未激活或已被删除，无法购买";
                }
                else
                {
                    //已经登录
                    if (!Page.IsPostBack)
                    {
                        //如果页面不是提交回来的
                        try
                        {
                            //这句可能有错
                            Guid courseID = new Guid(Request.QueryString["course_id"]);
                            Course toBuyCourse = new Course();
                            toBuyCourse.Course_id = courseID;
                            Course entireCourse = CourseOpr.GetCourseByID(toBuyCourse);
                            if (entireCourse != null)
                            {
                                //如果找到了课程
                                lblCourseName.Text = "要购买的课程为：" + entireCourse.Course_name;
                                lblCoursePrice.Text = "单价为：" + entireCourse.Course_price.ToString() + "令咒每日";
                                lblUserMoney.Text = "您当前余额为：" + loggedUser.User_money + "令咒";

                            }
                            else
                            {
                                lblCourseStateus.Text = "课程不存在";
                                lblCourseStateus.Visible = true;
                                BuyCourseForm.Visible = false;
                            }
                        }
                        catch
                        {
                            lblCourseStateus.Text = "课程ID错误";
                            lblCourseStateus.Visible = true;
                            BuyCourseForm.Visible = false;
                        }
                    }
                    else
                    {
                        //用户选择进行购买
                        try
                        {
                            Guid courseID = new Guid(Request.QueryString["course_id"]);
                            Course toBuyCourse = new Course();
                            toBuyCourse.Course_id = courseID;
                            Course entireCourse = CourseOpr.GetCourseByID(toBuyCourse);
                            if (entireCourse != null)
                            {
                                //找到了课程
                                //好，这里Course和User全有了，我们就要Create一个Order了！
                                Order newOrder = OrderOpr.CreateOrderByUserAndCourse(entireCourse, loggedUser);
                                //这句话转换可能出错
                                int toBuyDays = Convert.ToInt32(Request.Form[txtCourseTime.ID]);
                                if (toBuyDays < 0)
                                {
                                    lblCourseStateus.Text = "购买天数不能小于0";
                                    lblCourseStateus.Visible = true;
                                }
                                else
                                {

                                    if (newOrder != null)
                                    {
                                        //这个newOrder里面只包含了course_id和user_id因此我们需要手动填充
                                        newOrder.Order_price = toBuyDays * entireCourse.Course_price;
                                        newOrder.Order_isDeleted = false;
                                        //因为存储过程里是直接扣钱的，所以这里默认付款
                                        newOrder.Order_isPaid = true;
                                        newOrder.Order_date = DateTime.Now;
                                        if (newOrder.Order_price <= loggedUser.User_money
                                            && OrderOpr.CreateOrder(newOrder)
                                            )
                                        {
                                            lblCourseStateus.Text = "恭喜！召唤女友成功，快去后宫里面转转吧~";
                                            lblCourseStateus.Visible = true;
                                        }
                                        else
                                        {
                                            lblCourseStateus.Text = "创建订单出错，可能是您余额不足导致的，请确保令咒充足后重试";
                                            lblCourseStateus.Visible = true;
                                        }
                                    }
                                    else
                                    {
                                        lblCourseStateus.Text = "创建订单出错，请稍后再试";
                                        lblCourseStateus.Visible = true;
                                    }
                                }
                            }
                            else
                            {
                                lblCourseStateus.Text = "所购买的课程不存在";
                                lblCourseStateus.Visible = true;
                            }
                        }
                        catch
                        {
                            BuyCourseForm.Visible = false;
                            lblCourseStateus.Text = "课程ID不正确";
                            lblCourseStateus.Visible = true;
                        }
                    }
                }
            }
        }

    }
}