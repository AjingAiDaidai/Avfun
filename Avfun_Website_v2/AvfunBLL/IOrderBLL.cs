using System;
namespace Avfun_BLL
{
    public interface IOrderBLL
    {
        bool CreateOrder(Avfun_UI.Order order);
        Avfun_UI.Order CreateOrderByUserAndCourse(Avfun_UI.Course course, Avfun_UI.User user);
        bool isLegalOrder(Avfun_UI.Order order);
    }
}
