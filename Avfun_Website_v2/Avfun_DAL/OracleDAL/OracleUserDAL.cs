using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avfun_DAL.OracleDAL
{
    class OracleUserDAL:IUserDAL
    {
        bool IUserDAL.ChangeUserPassword(Avfun_UI.User user, string newPassword)
        {
            throw new NotImplementedException();
        }

        int IUserDAL.CreateUser(Avfun_UI.User user)
        {
            throw new NotImplementedException();
        }

        bool IUserDAL.GetForgetPassword(Avfun_UI.User user)
        {
            throw new NotImplementedException();
        }

        Avfun_UI.User IUserDAL.GetUserByAccountAndPassword(Avfun_UI.User user)
        {
            throw new NotImplementedException();
        }

        Avfun_UI.User IUserDAL.GetUserByID(Avfun_UI.User user)
        {
            throw new NotImplementedException();
        }

        USER[] IUserDAL.GetUsers()
        {
            throw new NotImplementedException();
        }

        int IUserDAL.InsertUser(Avfun_UI.User user)
        {
            throw new NotImplementedException();
        }

        bool IUserDAL.UpdateUserInfo(Avfun_UI.User user)
        {
            throw new NotImplementedException();
        }
    }
}
