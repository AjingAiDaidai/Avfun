using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Avfun_UI;
using Avfun_DAL;
namespace Avfun_BLL
{
    public class CourseBLL : ICourseBLL
    {

        /// <summary>
        /// 判断课程类Course的实例是否合法，合法返回true否则返回false
        /// </summary>
        /// <param name="course">要判断的课程类Course的实例</param>
        /// <returns>合法返回true，否则返回false</returns>
        public  Boolean isLegalCourse(Course course)
        {
            Boolean result = true;
            if (course.Course_id == null)
                result = false;
            if (string.IsNullOrEmpty(course.Course_name)
                || course.Course_name.Length > 256
                )
                result = false;
            if (course.Course_price < 0.0d)
                result = false;
            if (string.IsNullOrEmpty(course.Course_robot_link)
                || course.Course_robot_link.Length > 256)
                result = false;
            if (course.Course_begin_date == null)
                result = false;
            return result;
        }
        /// <summary>
        /// 添加一个新课程，成功返回true，失败返回false
        /// </summary>
        /// <param name="course">包含要添加新课程信息的Course类实例</param>
        /// <returns>成功返回true，失败返回false</returns>
        public  Boolean CreateCourse(Course course)
        {
            Boolean result = true;
            if (isLegalCourse(course))
            {
                ICourseDAL courseDAL = DALFactory.CreateInstance<ICourseDAL>("CourseDAL");
                result = courseDAL.CreateCourse(course);
            }
            else
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 根据ID获取课程的详细信息，如果获取到返回对应的Course类实例，否则返回null
        /// </summary>
        /// <param name="course">要查找的Course类实例，其中course_id必填</param>
        /// <returns>查找到返回包含全部信息的Course类实例，否则返回null</returns>
        public  Course GetCourseByID(Course course)
        {
            //数据合法性检查
            Course result = null;
            if (course.Course_id != null)
            {
                ICourseDAL courseDAL = DALFactory.CreateInstance<ICourseDAL>("CourseDAL");
                result = courseDAL.GetCourseByID(course);
            }
            else
            {
                result = null;
            }
            return result;
        }
        /// <summary>
        /// 更新课程信息，course是包括完整（更新后）课程信息的Course类实例
        /// </summary>
        /// <param name="course">包含完整课程信息的Course类实例</param>
        /// <returns>成功返回true，否则返回false</returns>
        public  Boolean UpdateCourseInfo(Course course)
        {
            Boolean result = false;
            if (isLegalCourse(course))
            {
                ICourseDAL courseDAL = DALFactory.CreateInstance<ICourseDAL>("CourseDAL");
                result = courseDAL.UpdateCourseInfo(course);
            }
            else
            {
                result = false;
            }
            return result;
        }

    }
}
