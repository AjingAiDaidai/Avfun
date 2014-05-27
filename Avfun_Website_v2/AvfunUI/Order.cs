using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*  订单类
 *  Author: LU YuXun 2014/5/13
 *  Version: 1
 *  Reference:http://msdn.microsoft.com/en-us/library/ms131092.aspx
 *  Update notes:
 *  NULL.UP-TO-DATE.
 *  
 *  注意：这里的外键关系并不对应Object！实在不行这里还可以改XD低耦合就是这点好。
 */
namespace Avfun_UI
{
    public class Order:GeneralOrder
    {
        private Guid order_user;

        public Guid Order_user
        {
            get { return order_user; }
            set { order_user = value; }
        }
        private Guid order_course;

        public Guid Order_course
        {
            get { return order_course; }
            set { order_course = value; }
        }
    
        public override int O_id
        {
            get { return this.o_id; }
        }

        public override Guid Order_id
        {
            get
            {
                return this.order_id;
            }
            set
            {
                this.order_id = value;
            }
        }

        public override DateTime Order_date
        {
            get
            {
                return this.order_date;
            }
            set
            {
                this.order_date = value;
            }
        }

        public override Double Order_price
        {
            get
            {
                return this.order_price;
            }
            set
            {
                this.order_price = value;
            }
        }

        public override bool Order_isPaid
        {
            get
            {
                return this.order_isPaid;
            }
            set
            {
                this.order_isPaid = value;
            }
        }

        public override bool Order_isDeleted
        {
            get
            {
                return this.order_isDeleted;
            }
            set
            {
                this.order_isDeleted = value;
            }
        }

        public Order(Order order)
        {
            this.o_id = order.O_id;
            this.order_id = order.Order_id;
            this.order_course = order.Order_course;
            this.order_user = order.Order_user;
            this.order_date = order.Order_date;
            this.order_price = order.Order_price;
            this.order_isPaid = order.Order_isPaid;
            this.order_isDeleted = order.Order_isDeleted;
        }
        public Order()
        {
        }
        public Order(Guid user, Guid course, float price, DateTime date)
        {
            this.order_user = user;
            this.order_course = course;
            this.order_price = price;
            this.order_date = date;
        }
    }
}