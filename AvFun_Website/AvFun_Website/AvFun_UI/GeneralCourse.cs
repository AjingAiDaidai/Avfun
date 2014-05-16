using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*  抽象课程类
 *  Author: LU YuXun 2014/5/13
 *  Version: 1
 *  Reference:http://msdn.microsoft.com/en-us/library/ms131092.aspx
 *  Update notes:
 *  NULL.UP-TO-DATE.
 */
namespace AvFun_Website.AvFun_UI
{
    public abstract class GeneralCourse
    {
        protected int c_id;

        public abstract int C_id
        {
            get;
        }
        protected Guid course_id;

        public abstract Guid Course_id
        {
            get;
            set;
        }
        /// <summary>
        /// 长256
        /// </summary>
        protected String course_name;

        public abstract String Course_name
        {
            get;
            set;
        }
        protected String course_intro;

        public abstract String Course_intro
        {
            get;
            set;
        }
        protected float course_price;

        public abstract float Course_price
        {
            get;
            set;
        }
        /// <summary>
        /// 长256
        /// </summary>
        protected String course_robot_link;

        public abstract String Course_robot_link
        {
            get;
            set;
        }
        protected DateTime course_begin_date;

        public abstract DateTime Course_begin_date
        {
            get;
            set;
        }
        protected Boolean course_isDeleted;

        public abstract Boolean Course_isDeleted
        {
            get;
            set;
        }

        protected byte[] course_timestamp;

        public byte[] Course_timestamp
        {
            get { return course_timestamp; }
            set { course_timestamp = value; }
        }


    }
}