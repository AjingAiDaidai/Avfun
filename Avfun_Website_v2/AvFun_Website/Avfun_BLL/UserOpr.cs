using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using AvFun_Website.AvFun_UI;
using AvFun_Website.Avfun_DAL;
namespace AvFun_Website.Avfun_BLL
{
    public class UserOpr
    {
        ///<summary>
        ///生成随机字符串
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
        ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
        ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        ///<returns>指定长度的随机字符串</returns>
        public String GenerateRandomString(int length,  //随机字符串长度
            bool useNum = true,  //是否用数字
            bool useLow = true,  //是否用小写
            bool useUpp = true,  //是否用大写
            bool useSpe = true,  //是否用特殊字符
            String custom = ""   //是否用用户自定义参数
            )
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            String s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }
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
        /// 根据用户ID获取用户信息，ID写在参数的user_id中
        /// </summary>
        /// <param name="user">包含用户id的User类实例</param>
        /// <returns>成功返回包含用户完整信息的User对象，失败返回null</returns>
        public  User GetUserByID(User user)
        {
        }
        /// <summary>
        /// 向新注册的用户发送激活账户的邮件
        /// public的原因是因为，重发确认信功能中也要用到
        /// </summary>
        /// <param name="newUser">刚刚创建的用户对应的UI.User实例</param>
        public  void SendVerifyMailToNewUser(User newUser)
        {
        }

        /// <summary>
        /// 向忘记密码的用户发送取回密码的邮件
        /// </summary>
        /// <param name="newUser">忘记密码的用户对应的UI.User实例，Account必填</param>
        /// <param name="newPasswordPlanText">新密码的明文，必填</param>
        public  void SendNewPasswordMailToUser(User newUser, String newPasswordPlanText)
        {
        }
        /// <summary>
        /// 注册时用户类的数据完整性检查，其实更改的时候也用得到啦！
        /// </summary>
        /// <param name="user">要检查的用户类</param>
        /// <returns>Boolean，true为合法，false为非法</returns>
        public  Boolean isLegalNewUser(User user)
        {
        }
        /// <summary>
        /// BLL层创建用户账号，由UI层调用，负责数据完整性检查和调用DAL层同名函数
        /// </summary>
        /// <param name="user">要创建的账号类</param>
        /// <returns>int，大于0说明成功，小于等于0说明调用失败。</returns>
         public  int CreateUser(User user)
        {
        }

        /// <summary>
        /// 根据账号和密码获得用户信息，返回一个符合查询条件的User，若不存在，返回null
        /// 其中参数的Account和Password必填
        /// </summary>
        /// <param name="user">要获得的User类，其中Account和Password必须填</param>
        /// <returns>User类或null</returns>
         public  User GetUserByAccountAndPassword(User user)
         {
         }
        /// <summary>
        /// 取回密码函数，成功返回true，否则返回false
        /// </summary>
        /// <param name="user">重设密码的User类，Account必填</param>
        /// <returns>成功返回true，否则返回false</returns>
 
        public  Boolean GetForgetPassword(User user)
         {

         }
        /// <summary>
        /// 检查参数中的User类实例是否可以作为合法的登录用户信息
        /// </summary>
        /// <param name="user">要检查的User类</param>
        /// <returns>合法返回true，否则false</returns>
        private Boolean isLegalLoginInfo(User user)
        {
        }
        /// <summary>
        /// 判断用户登录是否合法，合法返回登录用户对应的User对象，非法返回null
        /// User对象的Account Password必填
        /// </summary>
        /// <param name="user">需要判断的User对象</param>
        /// <returns>User类的实例</returns>
        public  User isLegalLogin(User user)
        {
        }
        /// <summary>
        /// 判断用户是否已经登录，如果登录那么返回包含用户信息的User对象，否则返回Null，相当于认证
        /// </summary>
        /// <param name="httpRequest">当前的httpRequest</param>
        /// <returns>已登录返回User对象，否则返回Null</returns>
        public  User isLogged(HttpRequest httpRequest)
        {
        }
        /// <summary>
        /// BAL修改用户密码，包括数据检验，成功返回true否则返回false
        /// </summary>
        /// <param name="user">要修改的用户</param>
        /// <param name="newPassword">新密码，应为32位MD5大写字符串</param>
        /// <returns>成功返回true否则false</returns>
        public  Boolean ChagneUserPassword(User user, String newPassword)
        {
        }
        /// <summary>
        /// 更新用户信息，会有isLegalLoginInfo检查的。成功返回true否则返回false
        /// </summary>
        /// <param name="user">要更新的user信息</param>
        /// <returns>成功返回true否则返回false</returns>
        public  Boolean UpdateUserInfo(User user)
        {
        }
        /// <summary>
        /// 激活用户，激活成功返回true，激活失败返回false
        /// </summary>
        /// <param name="user">要激活的，包含完整信息的User类</param>
        /// <param name="verifyCode">页面接受的验证码</param>
        /// <returns>激活成功返回ture，激活失败返回false</returns>
        public  Boolean CheckUser(User user, Guid verifyCode)
        {

        }
        /// <summary>
        /// 获取UserOpr类的一个实例
        /// </summary>
        /// <returns></returns>
        public static UserOpr GetNewInstnace()
        {
        }
    }
}