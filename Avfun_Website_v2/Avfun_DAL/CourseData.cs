using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Avfun_UI;

namespace Avfun_DAL
{
    public class CourseData
    {
        /// <summary>
        /// 将从数据库中获取的COURSE类转换为Course类
        /// </summary>
        /// <param name="course">要转换的COURSE类实例</param>
        /// <returns>转换完毕的对应Course类实例</returns>
        public Course ConvertCOURSEToCourse(COURSE course)
        {
            Course result = new Course();
            result.Course_id = course.course_id;
            result.Course_intro = course.course_intro;
            result.Course_name = course.course_name;
            result.Course_price = course.course_price;
            result.Course_robot_link = course.course_robot_link;
            result.Course_begin_date = course.course_begin_date;
            result.Course_isDeleted = course.course_isDeleted;
            result.Course_timestamp = course.course_timestamp;
            return result;
        }
        /// <summary>
        /// 将Course类转换为COURSE类
        /// </summary>
        /// <param name="course">要转换的Course类</param>
        /// <returns>转换后对应的COURSE类实例</returns>
        public COURSE ConvertCourseToCOURSE(Course course)
        {
            COURSE ResultCOURSE = new COURSE();
            ResultCOURSE.course_id = course.Course_id;
            ResultCOURSE.course_intro = course.Course_intro;
            ResultCOURSE.course_name = course.Course_name;
            ResultCOURSE.course_price = course.Course_price;
            ResultCOURSE.course_robot_link = course.Course_robot_link;
            ResultCOURSE.course_begin_date = course.Course_begin_date;
            ResultCOURSE.course_isDeleted = course.Course_isDeleted;
            return ResultCOURSE;
        }
        /// <summary>
        /// 新增课程，数据完整性检查在BLL层做。成功返回true，失败返回false
        /// </summary>
        /// <param name="course">包含新增课程信息的Course类实例</param>
        /// <returns>成功返回true，失败返回false</returns>
        public Boolean CreateCourse(Course course)
        {
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            COURSE newCOURSE = ConvertCourseToCOURSE(course);
            Boolean result = false ;
            try
            {
                DataEntity.COURSE.AddObject(newCOURSE);
                DataEntity.SaveChanges();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 根据ID获取包含完整信息的Course类实例
        /// </summary>
        /// <param name="course">包含id字段的Course类实例</param>
        /// <returns>包含完整信息的Course类实例</returns>
        public Course GetCourseByID(Course course)
        {
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            Course result = null;
            try
            {
                COURSE toFindCourse = (from c in DataEntity.COURSE
                                      where
                                      c.course_id == course.Course_id
                                      select c).Single();
                result = ConvertCOURSEToCourse(toFindCourse);
            }
            catch
            {
                result = null;
            }
            return result;
        }
        /// <summary>
        /// 更新课程信息，course为包含完整的要更新的课程信息的Course类实例
        /// </summary>
        /// <param name="course">包含完整要更新的课程信息的Course类实例</param>
        /// <returns></returns>
        public Boolean UpdateCourseInfo(Course course)
        {
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            Boolean result = false;
            try
            {
                COURSE toUpdateCourse = ( from c in DataEntity.COURSE
                                          where 
                                          c.course_id == course.Course_id
                                          &&
                                          c.course_timestamp == course.Course_timestamp
                                          select c
                                          ).Single();
                toUpdateCourse.course_intro = course.Course_intro;
                toUpdateCourse.course_name = course.Course_name;
                toUpdateCourse.course_price = course.Course_price;
                toUpdateCourse.course_robot_link = course.Course_robot_link;
                toUpdateCourse.course_begin_date = course.Course_begin_date;
                toUpdateCourse.course_isDeleted = course.Course_isDeleted;
                DataEntity.SaveChanges();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 获取CourseData的一个实例，为了方便以后做成单例模式用
        /// </summary>
        /// <returns>CourseData的一个实例</returns>
        public static CourseData GetNewInstance()
        {
            return new CourseData();
        }
      
    }
}