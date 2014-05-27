using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avfun_UI;
using Avfun_DAL;
namespace Avfun_BLL
{
    public class OrderBLL : IOrderBLL
    {

        /// <summary>
        /// 判断Order类的实例中数据类型是否合法
        /// </summary>
        /// <param name="order">要判断的Order类实例</param>
        /// <returns>成功返回true，失败返回false</returns>
        public  Boolean isLegalOrder(Order order)
        {
            Boolean result = true;
            if (order.Order_id == null)
                result = false;
            if (order.Order_date == null)
                result = false;
            if (order.Order_course == null)
                result = false;
            if (order.Order_user == null)
                result = false;
            if (order.Order_price < 0.0
                || order.Order_price == null)
                result = false;
            return result;
        }
        /// <summary>
        /// 在数据库中创建订单
        /// </summary>
        /// <param name="order">包含完整信息的Order实例</param>
        /// <returns>成功返回true，失败返回false</returns>
        public  Boolean CreateOrder(Order order)
        {
            Boolean result = false;
            if (isLegalOrder(order))
            {
                OrderData orderData = OrderData.GetNewInstance();
                result = orderData.CreateOrder(order);
            }
            else
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 根据用户和课程创建订单，注意，所有要这么干的地方，必须调用该函数而不是new一个出来！
        /// </summary>
        /// <param name="course">用户购买的课程</param>
        /// <param name="user">登录的用户</param>
        /// <returns>一个Order类的Instance</returns>
        public  Order CreateOrderByUserAndCourse(Course course, User user)
        {
            Order result = null;
            IUserBLL userBLL = BLLFactory.CreateInstance<IUserBLL>("UserBLL");
            ICourseBLL courseBLL = BLLFactory.CreateInstance<ICourseBLL>("CourseBLL");
            if (userBLL.isLegalNewUser(user)
                && courseBLL.isLegalCourse(course))
            {
                result = new Order();
                result.Order_course = course.Course_id;
                result.Order_user = user.User_id;
            }
            else
            {
                result = null;
            }
            return result;
        }
    }
}
