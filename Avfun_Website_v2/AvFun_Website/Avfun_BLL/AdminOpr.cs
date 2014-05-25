using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

using AvFun_Website.AvFun_UI;
using AvFun_Website.Avfun_DAL;
namespace AvFun_Website.Avfun_BLL
{
    public class AdminOpr
    {
        /// <summary>
        /// 判断参数Admin是否符合数据库规范，创建用户时的数据合法性检验
        /// </summary>
        /// <param name="admin">要检查的Admin对象</param>
        /// <returns>合法返回true，否则返回false</returns>
        public Boolean isLegalNewAdmin(Admin admin)
        {
        }
        /// <summary>
        /// 判断参数admin是否符合登录的数据要求，数据验证用数据合法性检验函数
        /// </summary>
        /// <param name="admin">待验证Admin对象</param>
        /// <returns>符合要求返回true，否则返回false</returns>
        public Boolean isLegalLoginInfo(Admin admin)
        {
        }
        /// <summary>
        /// 管理员登录用函数，成功则返回对应的Admin对象，否则返回null
        /// </summary>
        /// <param name="admin">要验证的Admin对象</param>
        /// <returns>成功返回Admin的详细信息，否则返回null</returns>
        public Admin isLegalLogin(Admin admin)
        {
        }
        /// <summary>
        /// 根据Request判断管理员是否登录，主要看Cookie，若登录了返回完整Admin对象
        /// </summary>
        /// <param name="httpRequest">需要判断的httpRequest</param>
        /// <returns>若已登录返回完整Admin对象，否则返回null</returns>
        public Admin isLogged(HttpRequest httpRequest)
        {
        }
        /// <summary>
        /// 更新管理员信息，成功返回true失败返回false
        /// </summary>
        /// <param name="admin">要更新的管理员</param>
        /// <returns>成功true失败false</returns>
        public Boolean UpdateAdminInfo(Admin admin)
        {
        }
        /// <summary>
        /// 根据参数中的user_id返回给定Admin的信息
        /// </summary>
        /// <param name="admin">要查找的Admin实例，user_id必填</param>
        /// <returns>成功返回Admin类，失败返回null</returns>
        public Admin GetAdminByID(Admin admin)
        {
        }
        /// <summary>
        /// 获取一个AdminOpr类的实例
        /// </summary>
        /// <returns></returns>
        public static AdminOpr GetNewInstance()
        {
        }
    }
}