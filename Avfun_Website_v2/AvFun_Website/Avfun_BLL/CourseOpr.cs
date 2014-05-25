using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AvFun_Website.AvFun_UI;
using AvFun_Website.Avfun_DAL;
namespace AvFun_Website.Avfun_BLL
{
    public class CourseOpr
    {
        /// <summary>
        /// 判断课程类Course的实例是否合法，合法返回true否则返回false
        /// </summary>
        /// <param name="course">要判断的课程类Course的实例</param>
        /// <returns>合法返回true，否则返回false</returns>
        public  Boolean isLegalCourse(Course course)
        {
        }
        /// <summary>
        /// 添加一个新课程，成功返回true，失败返回false
        /// </summary>
        /// <param name="course">包含要添加新课程信息的Course类实例</param>
        /// <returns>成功返回true，失败返回false</returns>
        public Boolean CreateCourse(Course course)
        {
        }
        /// <summary>
        /// 根据ID获取课程的详细信息，如果获取到返回对应的Course类实例，否则返回null
        /// </summary>
        /// <param name="course">要查找的Course类实例，其中course_id必填</param>
        /// <returns>查找到返回包含全部信息的Course类实例，否则返回null</returns>
        public Course GetCourseByID(Course course)
        {
        }
        /// <summary>
        /// 更新课程信息，course是包括完整（更新后）课程信息的Course类实例
        /// </summary>
        /// <param name="course">包含完整课程信息的Course类实例</param>
        /// <returns>成功返回true，否则返回false</returns>
        public Boolean UpdateCourseInfo(Course course)
        {
        }
        /// <summary>
        /// 获取一个CourseOpr类的实例
        /// </summary>
        /// <returns></returns>
        public CourseOpr GetNewInstance()
        {
        }
    }
}