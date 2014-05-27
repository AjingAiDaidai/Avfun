using System;
namespace Avfun_DAL
{
    public interface ICourseDAL
    {
        Avfun_UI.Course ConvertCOURSEToCourse(COURSE course);
        COURSE ConvertCourseToCOURSE(Avfun_UI.Course course);
        bool CreateCourse(Avfun_UI.Course course);
        Avfun_UI.Course GetCourseByID(Avfun_UI.Course course);
        bool UpdateCourseInfo(Avfun_UI.Course course);
    }
}
