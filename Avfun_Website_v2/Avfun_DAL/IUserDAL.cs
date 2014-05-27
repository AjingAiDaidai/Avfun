using System;
namespace Avfun_DAL
{
    public interface IUserDAL
    {
        bool ChangeUserPassword(Avfun_UI.User user, string newPassword);
        int CreateUser(Avfun_UI.User user);
        bool GetForgetPassword(Avfun_UI.User user);
        Avfun_UI.User GetUserByAccountAndPassword(Avfun_UI.User user);
        Avfun_UI.User GetUserByID(Avfun_UI.User user);
        USER[] GetUsers();
        int InsertUser(Avfun_UI.User user);
        bool UpdateUserInfo(Avfun_UI.User user);
    }
}
