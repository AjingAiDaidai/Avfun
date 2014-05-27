using System;
namespace Avfun_DAL
{
    public interface IOrderDAL
    {
        bool CreateOrder(Avfun_UI.Order order);
    }
}
