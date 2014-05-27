using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avfun_UI
{
    public abstract class GeneralOrder
    {
        protected int o_id;

        public abstract int O_id
        {
            get;
        }
        protected Guid order_id;

        public abstract Guid Order_id
        {
            get;
            set;
        }
        protected DateTime order_date;

        public abstract DateTime Order_date
        {
            get;
            set;
        }
        protected Double order_price;

        public abstract Double Order_price
        {
            get;
            set;
        }
        protected Boolean order_isPaid;

        public abstract Boolean Order_isPaid
        {
            get;
            set;
        }
        protected Boolean order_isDeleted;

        public abstract Boolean Order_isDeleted
        {
            get;
            set;
        }
        protected byte[] Order_timestamp;

        public byte[] Order_timestamp1
        {
            get { return Order_timestamp; }
            set { Order_timestamp = value; }
        }
        
    }
}