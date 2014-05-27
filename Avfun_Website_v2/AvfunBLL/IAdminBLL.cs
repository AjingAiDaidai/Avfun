using System;
using Avfun_UI;
namespace Avfun_BLL
{
    public interface IAdminBLL
    {
         String MD5(String str);
         Admin GetAdminByID(Admin admin);
         Admin isLegalLogin(Admin admin);
         bool isLegalLoginInfo(Admin admin);
         bool isLegalNewAdmin(Admin admin);
         Admin isLogged(System.Web.HttpRequest httpRequest);
         bool UpdateAdminInfo(Admin admin);
    }
}
