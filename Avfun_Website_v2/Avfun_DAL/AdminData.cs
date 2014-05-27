using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Avfun_UI;
namespace Avfun_DAL
{
    public class AdminData
    {
        /// <summary>
        /// 将ADMIN对象转换为Admin对象,a_id这里没管因为没意义
        /// </summary>
        /// <param name="admin">要转换的Admin对象</param>
        /// <returns>转换后的ADMIN对象</returns>
        public ADMIN ConvertAdminToADMIN(Admin admin)
        {
            /*数据库里就这5个*/
            ADMIN result = new ADMIN();
            result.admin_id = admin.User_id;
            result.admin_account = admin.User_account;
            result.admin_password = admin.User_password;
            result.admin_last_login_time = admin.User_last_login_date;
            result.admin_last_login_ip = admin.User_last_login_ip;
            result.admin_nickname = admin.User_nickname;
            result.admin_timestamp = admin.User_timestamp;
            return result;
        }
        /// <summary>
        /// 将ADMIN类转换为Admin类，a_id在这里没管，因为无意义。
        /// </summary>
        /// <param name="admin">要转换的ADMIN类对象</param>
        /// <returns>等价的Admin对象</returns>
        public Admin ConvertADMINToAdmin(ADMIN admin)
        {
            Admin result = new Admin();
            result.User_id = admin.admin_id;
            result.User_account = admin.admin_account;
            result.User_password = admin.admin_password;
            result.User_last_login_date = admin.admin_last_login_time;
            result.User_last_login_ip = admin.admin_last_login_ip;
            result.User_nickname = admin.admin_nickname;
            result.User_timestamp = admin.admin_timestamp;
            return result;
        }
        /// <summary>
        /// 根据账号密码获得数据库中的admin实例
        /// </summary>
        /// <param name="admin">要查找的Admin对象</param>
        /// <returns>成功返回Admin对象，未找到或失败返回null</returns>
        public Admin GetAdminByAccountAndPassword(Admin admin)
        {
            Admin result = null;
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            try
            {
            ADMIN result_admin = (from usr in DataEntity.ADMIN
                                 where usr.admin_account == admin.User_account
                                 && usr.admin_password == admin.User_password
                                      select usr).Single();
                result = ConvertADMINToAdmin(result_admin);
            }
            catch
            {
                result = null;
            }
            return result;
        }
        /// <summary>
        /// 更新管理员信息，由BLL层调用，成功返回true，失败返回fales；
        /// </summary>
        /// <param name="admin">要更新的管理员Admin实例</param>
        /// <returns>成功返回true，失败返回false</returns>
        public Boolean UpdateAdminInfo(Admin admin)
        {
            Boolean result = false;
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            try
            {
                ADMIN destAdmin = ( from usr in DataEntity.ADMIN 
                                    where usr.admin_id == admin.User_id
                                    && usr.admin_timestamp == admin.User_timestamp
                                    select usr).Single();
                //全套更新
                destAdmin.admin_id = admin.User_id;
                destAdmin.admin_account = admin.User_account;
                destAdmin.admin_password = admin.User_password;
                destAdmin.admin_last_login_time = admin.User_last_login_date;
                destAdmin.admin_last_login_ip = admin.User_last_login_ip;
                destAdmin.admin_nickname = admin.User_nickname;

                DataEntity.SaveChanges();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 这里为了以后做成单例模式不时之需
        /// </summary>
        /// <returns>AdminData的实例</returns>
        public static AdminData GetNewInstance()
        {
            return new AdminData();
        }

    }
}