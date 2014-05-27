using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avfun_DAL.OracleDAL
{
    class OracleAdminDAL:IAdminDAL
    {
        Avfun_UI.Admin IAdminDAL.ConvertADMINToAdmin(ADMIN admin)
        {
            throw new NotImplementedException();
        }

        ADMIN IAdminDAL.ConvertAdminToADMIN(Avfun_UI.Admin admin)
        {
            throw new NotImplementedException();
        }

        Avfun_UI.Admin IAdminDAL.GetAdminByAccountAndPassword(Avfun_UI.Admin admin)
        {
            throw new NotImplementedException();
        }

        bool IAdminDAL.UpdateAdminInfo(Avfun_UI.Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
