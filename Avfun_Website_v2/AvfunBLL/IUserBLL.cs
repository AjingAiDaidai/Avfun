using System;
using System.Web;
namespace Avfun_BLL
{
    public interface IUserBLL
    {
        bool ChagneUserPassword(Avfun_UI.User user, string newPassword);
        bool CheckUser(Avfun_UI.User user, Guid verifyCode);
        int CreateUser(Avfun_UI.User user);
        string GenerateRandomString(int length, bool useNum = true, bool useLow = true, bool useUpp = true, bool useSpe = true, string custom = "");
        bool GetForgetPassword(Avfun_UI.User user);
        Avfun_UI.User GetUserByAccountAndPassword(Avfun_UI.User user);
        Avfun_UI.User GetUserByID(Avfun_UI.User user);
        Avfun_UI.User isLegalLogin(Avfun_UI.User user);
        bool isLegalNewUser(Avfun_UI.User user);
        Avfun_UI.User isLogged(HttpRequest httpRequest);
        string MD5(string str);
        void SendNewPasswordMailToUser(Avfun_UI.User newUser, string newPasswordPlanText);
        void SendVerifyMailToNewUser(Avfun_UI.User newUser);
        bool UpdateUserInfo(Avfun_UI.User user);
    }
}
