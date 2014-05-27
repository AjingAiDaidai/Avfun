using System;
namespace Avfun_BLL
{
    public interface ICourseBLL
    {
        bool CreateCourse(Avfun_UI.Course course);
        Avfun_UI.Course GetCourseByID(Avfun_UI.Course course);
        bool isLegalCourse(Avfun_UI.Course course);
        bool UpdateCourseInfo(Avfun_UI.Course course);
    }
}
