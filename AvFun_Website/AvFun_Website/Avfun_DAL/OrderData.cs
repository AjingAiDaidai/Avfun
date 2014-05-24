using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AvFun_Website.Avfun_BLL;
using AvFun_Website.AvFun_UI;
namespace AvFun_Website.Avfun_DAL
{
    public class OrderData
    {
        /// <summary>
        /// 在数据库中创建订单，调用的是数据库中的CreateNewOrder存储过程。这个函数有事务保护
        /// </summary>
        /// <param name="order">包含订单信息的完整order类</param>
        /// <returns>成功返回true，否则返回false</returns>
        public  Boolean CreateOrder(Order order)
        {
            Boolean result = false;
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            try
            {
                DataEntity.CreateNewOrder
                        (order.Order_price, order.Order_user, order.Order_course, BitConverter.GetBytes(order.Order_isPaid));

                result = true;
                
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static OrderData GetNewInstance()
        {
            return new OrderData();
        }
    }
}