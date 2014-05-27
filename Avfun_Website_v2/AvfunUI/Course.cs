using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avfun_UI
{
    public class Course:GeneralCourse
    {
        public override int C_id
        {
            get { return this.c_id; }
        }

        public override Guid Course_id
        {
            get
            {
                return this.course_id;
            }
            set
            {
                this.course_id = value;
            }
        }

        public override String Course_name
        {
            get
            {
                return this.course_name;
            }
            set
            {
                this.course_name = value;
            }
        }

        public override string Course_intro
        {
            get
            {
                return this.course_intro;
            }
            set
            {
                this.course_intro = value;
            }
        }

        public override Double Course_price
        {
            get
            {
                return this.course_price;
            }
            set
            {
                this.course_price = value;
            }
        }

        public override String Course_robot_link
        {
            get
            {
                return this.course_robot_link;
            }
            set
            {
                this.course_robot_link = value;
            }
        }

        public override DateTime Course_begin_date
        {
            get
            {
                return this.course_begin_date;
            }
            set
            {
                this.course_begin_date = value;
            }
        }

        public override bool Course_isDeleted
        {
            get
            {
                return this.course_isDeleted;
            }
            set
            {
                this.course_isDeleted = value;
            }
        }

        public Course(Course course)
        {
            this.c_id = course.C_id;
            this.course_id = course.Course_id;
            this.course_name = course.Course_name;
            this.course_intro = course.Course_intro;
            this.course_price = course.Course_price;
            this.course_robot_link = course.Course_robot_link;
            this.course_begin_date = course.Course_begin_date;
            this.course_isDeleted = course.Course_isDeleted;
        }
        public Course(String course_name, String course_intro, Double course_price, String course_robot_link, DateTime course_begin_date)
        {
            this.course_name = course_name;
            this.course_intro = course_intro;
            this.course_price = course_price;
            this.course_robot_link = course_robot_link;
            this.course_begin_date = course_begin_date;
        }
        public Course()
        {
        }
    }
}