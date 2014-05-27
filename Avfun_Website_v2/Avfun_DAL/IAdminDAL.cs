using System;
namespace Avfun_DAL
{
    public interface IAdminDAL
    {
        Avfun_UI.Admin ConvertADMINToAdmin(ADMIN admin);
        ADMIN ConvertAdminToADMIN(Avfun_UI.Admin admin);
        Avfun_UI.Admin GetAdminByAccountAndPassword(Avfun_UI.Admin admin);
        bool UpdateAdminInfo(Avfun_UI.Admin admin);
    }
}
