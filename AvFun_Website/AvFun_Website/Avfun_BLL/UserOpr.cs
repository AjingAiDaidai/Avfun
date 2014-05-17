using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AvFun_Website.AvFun_UI;
using AvFun_Website.Avfun_DAL;
namespace AvFun_Website.Avfun_BLL
{
    public class UserOpr:IUser
    {
        /// <summary>
        /// MD5加密函数，返回大写的32位MD5加密值
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>32位大写MD5，加密后的值</returns>
        public static String MD5(String str)
        {
           return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper();  
        }
        public User GetUserByID(User user)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 用户类的数据完整性检查
        /// </summary>
        /// <param name="user">要检查的用户类</param>
        /// <returns>Boolean，true为合法，false为非法</returns>
        private static Boolean isLegalUser(User user)
        {
            Boolean result = true;
            // 用户账号不能为空
            if (user.User_account == null)
            {
                result = false;
            }
            String user_password = user.User_password;
            // 用户密码不能为空
            if (user_password == null)
            {
                result = false;
            }
            // 用户密码长度不能不等于32，因为传入的是加密的
            if (user_password.Length != 32)
            {
                result = false;
            }
            // 最后登录ip不能为空
            if (user.User_last_login_ip == null)
            {
                result = false;
            }
            // 头像不能为空
            if (user.User_head == null)
            {
                result = false;
            }
            // 昵称不能为空
            if (user.User_nickname == null)
            {
                result = false;
            }
            //余额不能小于0
            if (user.User_money < 0.0f)
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// BLL层创建用户账号，由UI层调用，负责数据完整性检查和调用DAL层同名函数
        /// </summary>
        /// <param name="user">要创建的账号类</param>
        /// <returns>int，大于0说明成功，小于等于0说明调用失败。</returns>
         public static int CreateUser(User user)
        {
            int res = 0;
            /*
                数据完整性检查
             */
            if (isLegalUser(user))
            {
                /*
                    添加用户，这里用异常处理的原因是，数据库中有userAccount唯一约束
                 */
                    UserData UserData_Create = new UserData();
                    res = UserData_Create.CreateUser(user);
               
            }
            else
            {
                res = 0;
            }
            return res;
        }
        /// <summary>
        /// 获取UserOpr的实例，这是为了以后视情况是否给该类改成单例的用的。
        /// </summary>
        /// <returns>UserOpr的一个实例</returns>
         public static UserOpr GetInstance()
         {
             return new UserOpr();
         }
    }
}