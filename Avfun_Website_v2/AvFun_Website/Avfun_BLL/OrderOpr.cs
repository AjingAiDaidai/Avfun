using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AvFun_Website.AvFun_UI;
using AvFun_Website.Avfun_DAL;
namespace AvFun_Website.Avfun_BLL
{
    public class OrderOpr
    {
        /// <summary>
        /// 判断Order类的实例中数据类型是否合法
        /// </summary>
        /// <param name="order">要判断的Order类实例</param>
        /// <returns>成功返回true，失败返回false</returns>
        public  Boolean isLegalOrder(Order order)
        {
        }
        /// <summary>
        /// 在数据库中创建订单
        /// </summary>
        /// <param name="order">包含完整信息的Order实例</param>
        /// <returns>成功返回true，失败返回false</returns>
        public  Boolean CreateOrder(Order order)
        {
        }
        /// <summary>
        /// 根据用户和课程创建订单，注意，所有要这么干的地方，必须调用该函数而不是new一个出来！
        /// </summary>
        /// <param name="course">用户购买的课程</param>
        /// <param name="user">登录的用户</param>
        /// <returns>一个Order类的Instance</returns>
        public  Order CreateOrderByUserAndCourse(Course course, User user)
        {
        }
        /// <summary>
        /// 获取OrderOpr类的一个实例
        /// </summary>
        /// <returns></returns>
        public static OrderOpr GetNewInstance()
        {
        }
    }
}