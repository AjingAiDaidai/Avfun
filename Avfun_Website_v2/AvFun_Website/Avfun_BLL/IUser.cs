using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AvFun_Website.AvFun_UI;
namespace AvFun_Website.Avfun_BLL
{
    interface IUser:IGeneralUser
    {
       User GetUserByID(User user);
    }
}
