using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/* 数据管理类
 * Author:LU YuXun，Date:2014/5/14
 * 说明：数据管理类，使用时请务必注意，获取DataEntity的时间应该尽量短，以避免可能的访问冲突
 * */
namespace Avfun_DAL
{
    public class DataEntityManager
    {
        public static avfunEntities GetDataEntity()
        {
            return new avfunEntities();
        }
    }
}