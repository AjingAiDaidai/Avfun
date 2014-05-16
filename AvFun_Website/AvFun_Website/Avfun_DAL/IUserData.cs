using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AvFun_Website.AvFun_UI;
namespace AvFun_Website.Avfun_DAL
{
    interface IUserData : IGeneralUserData
    {
        int CreateUser(User user);
        int InsertUser(User user);
        USER[] GetUsers();
        User GetUserByID(User user);
    }
}
