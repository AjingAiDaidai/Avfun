using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Avfun_UI;
using Avfun_DAL;
namespace Avfun_BLL
{
    public class AdminBLL : IAdminBLL
    {

        /// <summary>
        /// MD5加密函数，返回大写的32位MD5加密值
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>32位大写MD5，加密后的值</returns>
        public String MD5(String str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper();
        }
        /// <summary>
        /// 判断参数Admin是否符合数据库规范，创建用户时的数据合法性检验
        /// </summary>
        /// <param name="admin">要检查的Admin对象</param>
        /// <returns>合法返回true，否则返回false</returns>
        public Boolean isLegalNewAdmin(Admin admin)
        {
            Boolean result = true;
            //账号合法性检验
            if (admin.User_account.Length > 64 //长于64不行
                || admin.User_account.Length < 5 //比5短也不行
                || admin.User_account == null //null不行
                || admin.User_account.Equals("") //isNotOrEmpty
                )
                result = false;

            //密码合法性检验
            if (admin.User_password.Length != 32 //长度不是32不行
                || admin.User_password.Equals("") //为空不行
                || admin.User_password == null) //是null也不行
                result = false;

            //登录日期检验
            if (admin.User_last_login_date == null) //为空不行
                result = false;
            //最后登录ip检验
            if (admin.User_last_login_ip == null //为空不行
                || admin.User_last_login_ip.Length < 8 //不能比8位短
                || admin.User_last_login_ip.Length > 64 //不能比64位长
                || admin.User_last_login_ip.Equals("") //为空不行
                )
                result = false;
            //时间戳不做校验
            return result;
        }
        /// <summary>
        /// 判断参数admin是否符合登录的数据要求，数据验证用数据合法性检验函数
        /// </summary>
        /// <param name="admin">待验证Admin对象</param>
        /// <returns>符合要求返回true，否则返回false</returns>
        public Boolean isLegalLoginInfo(Admin admin)
        {
            Boolean result = true;
            //账号合法性检验
            if (admin.User_account.Length > 64 //长于64不行
                || admin.User_account.Length < 5 //比5短也不行
                || admin.User_account == null //null不行
                || admin.User_account.Equals("") //isNotOrEmpty
                )
                result = false;

            //密码合法性检验
            if (admin.User_password.Length != 32 //长度不是32不行
                || admin.User_password.Equals("") //为空不行
                || admin.User_password == null) //是null也不行
                result = false;
            return result;
        }
        /// <summary>
        /// 管理员登录用函数，成功则返回对应的Admin对象，否则返回null
        /// </summary>
        /// <param name="admin">要验证的Admin对象</param>
        /// <returns>成功返回Admin的详细信息，否则返回null</returns>
        public Admin isLegalLogin(Admin admin)
        {
            Admin result = null;
            if (isLegalLoginInfo(admin))
            {
                AdminData adminData = AdminData.GetNewInstance();
                result = adminData.GetAdminByAccountAndPassword(admin);
            }
            return result;
        }
        /// <summary>
        /// 根据Request判断管理员是否登录，主要看Cookie，若登录了返回完整Admin对象
        /// </summary>
        /// <param name="httpRequest">需要判断的httpRequest</param>
        /// <returns>若已登录返回完整Admin对象，否则返回null</returns>
        public Admin isLogged(HttpRequest httpRequest)
        {
            //构造登录用类
            Admin loginAdmin = new Admin();
            Admin result = null;
            if (httpRequest.Cookies["adminAccount"] == null
                || httpRequest.Cookies["adminPassword"] == null
                || httpRequest.Cookies["adminAccount"].Value.Length > 64
                || httpRequest.Cookies["adminPassword"].Value.Length != 32
                )
                return null;
            else
            {
                loginAdmin.User_account = httpRequest.Cookies["adminAccount"].Value;
                loginAdmin.User_password = httpRequest.Cookies["adminPassword"].Value;

                //登录，返回结果
                if (isLegalLoginInfo(loginAdmin))
                {
                    result = isLegalLogin(loginAdmin);
                }
            }
            return result;
        }
        /// <summary>
        /// 更新管理员信息，成功返回true失败返回false
        /// </summary>
        /// <param name="admin">要更新的管理员</param>
        /// <returns>成功true失败false</returns>
        public Boolean UpdateAdminInfo(Admin admin)
        {
            Boolean result = false;
            if (isLegalNewAdmin(admin))
            {
                //数据完整性检查通过
                AdminData adminData = AdminData.GetNewInstance();
                result = adminData.UpdateAdminInfo(admin);
            }
            return result;
        }
        /// <summary>
        /// 根据参数中的user_id返回给定Admin的信息
        /// </summary>
        /// <param name="admin">要查找的Admin实例，user_id必填</param>
        /// <returns>成功返回Admin类，失败返回null</returns>
        public Admin GetAdminByID(Admin admin)
        {
            Admin result = null;
            return result;
        }
    }
}