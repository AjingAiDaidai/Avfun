using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using AvFun_Website.AvFun_UI;
using AvFun_Website.Avfun_DAL;
namespace AvFun_Website.Avfun_BLL
{
    public class UserOpr:IUser
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
        public static String GenerateRandomString(int length,  //随机字符串长度
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
        public static String MD5(String str)
        {
           return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper();  
        }
        public User GetUserByID(User user)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 向新注册的用户发送激活账户的邮件
        /// public的原因是因为，重发确认信功能中也要用到
        /// </summary>
        /// <param name="newUser">刚刚创建的用户对应的UI.User实例</param>
        public static void SendVerifyMailToNewUser(User newUser)
        {
            #region 准备阶段
            //读取信息
            /* WebConfig内容
             *     <add key ="domain" value="http://localhost:30052/"/>
    <add key ="MailAddress" value="0daydigger.avfun@gmail.com"/>
    <add key ="MailPassword" value="hhxbyfdopdadawxz"/>
    <add key ="MailNickname" value ="Avfun管理组"/>
    <add key ="MailSubject" value ="【Avfun用户管理组账号激活提醒】"/>
             * */
            String WebDomain = ReadWebConfig.GetAppSettingValue("Domain");
            String MailAddress = ReadWebConfig.GetAppSettingValue("MailAddress");
            String MailPassword = ReadWebConfig.GetAppSettingValue("MailPassword");
            String MailNickname = ReadWebConfig.GetAppSettingValue("MailNickname");
            String MailSubject = ReadWebConfig.GetAppSettingValue("MailSubject");
            #endregion
            #region 发信模块
            MailMessage mail = new MailMessage();

            //前面是發信email後面是顯示的名稱
            mail.From = new MailAddress(MailAddress, MailNickname);
            //收信者email
            mail.To.Add(newUser.User_account);
            //設定優先權
            mail.Priority = MailPriority.Normal;
            //標題
            mail.Subject = MailSubject + newUser.User_nickname;

            //內容
            mail.Body =
                "尊敬的Avfun用户:" + newUser.User_nickname + "："
                + "<br/>您好 "
                + "<br/>您的激活地址是"
                // WebDomain 以 "/"结尾
                + "<br/>" + WebDomain + "checkUser.aspx?VerifyCode=" + newUser.User_verify_code
                + "<br/>请复制到浏览器中打开，完成激活"
                + "<br/> Avfun管理组，敬上";

                

            //內容使用html
            mail.IsBodyHtml = true;

            //設定gmail的smtp
            SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);

            //您在gmail的帳號密碼
            MySmtp.Credentials = new System.Net.NetworkCredential(MailAddress, MailPassword);

            //開啟ssl
            MySmtp.EnableSsl = true;
            
            //發送郵件
            MySmtp.Send(mail);

            //放掉宣告出來的MySmtp
            MySmtp = null;

            //放掉宣告出來的mail
            mail.Dispose();
            #endregion 发信模块
        }

        /// <summary>
        /// 向忘记密码的用户发送取回密码的邮件
        /// </summary>
        /// <param name="newUser">忘记密码的用户对应的UI.User实例，Account必填</param>
        /// <param name="newPasswordPlanText">新密码的明文，必填</param>
        public static void SendNewPasswordMailToUser(User newUser, String newPasswordPlanText)
        {
            #region 准备阶段
            //读取信息
            /* WebConfig内容
             *     <add key ="domain" value="http://localhost:30052/"/>
    <add key ="MailAddress" value="0daydigger.avfun@gmail.com"/>
    <add key ="MailPassword" value="hhxbyfdopdadawxz"/>
    <add key ="MailNickname" value ="Avfun管理组"/>
    <add key ="MailSubject" value ="【Avfun用户管理组账号激活提醒】"/>
             * */
            String WebDomain = ReadWebConfig.GetAppSettingValue("Domain");
            String MailAddress = ReadWebConfig.GetAppSettingValue("MailAddress");
            String MailPassword = ReadWebConfig.GetAppSettingValue("MailPassword");
            String MailNickname = ReadWebConfig.GetAppSettingValue("MailNickname");
            String MailSubject = ReadWebConfig.GetAppSettingValue("MailGetPasswordSubject");
            #endregion
            #region 发信模块
            MailMessage mail = new MailMessage();

            //前面是發信email後面是顯示的名稱
            mail.From = new MailAddress(MailAddress, MailNickname);
            //收信者email
            mail.To.Add(newUser.User_account);
            //設定優先權
            mail.Priority = MailPriority.Normal;
            //標題
            mail.Subject = MailSubject + newUser.User_nickname;

            //內容
            mail.Body =
                "尊敬的Avfun用户:"
                + "<br/>您好 "
                + "<br/>您的新密码是" + newPasswordPlanText
                + "<br/>请牢记您的新密码并及时更改"
                + "<br/> Avfun管理组，敬上";



            //內容使用html
            mail.IsBodyHtml = true;

            //設定gmail的smtp
            SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);

            //您在gmail的帳號密碼
            MySmtp.Credentials = new System.Net.NetworkCredential(MailAddress, MailPassword);

            //開啟ssl
            MySmtp.EnableSsl = true;

            //發送郵件
            MySmtp.Send(mail);

            //放掉宣告出來的MySmtp
            MySmtp = null;

            //放掉宣告出來的mail
            mail.Dispose();
            #endregion 发信模块
        }
        /// <summary>
        /// 注册时用户类的数据完整性检查，其实更改的时候也用得到啦！
        /// </summary>
        /// <param name="user">要检查的用户类</param>
        /// <returns>Boolean，true为合法，false为非法</returns>
        public static Boolean isLegalNewUser(User user)
        {
            Boolean result = true;
            // 用户账号不能为空，不能不写，长度不能小于5，不能大于64
            // @z.cn就5个了，怎么也不能比这个小吧？
            if (user.User_account == null || 
                user.User_account.Equals("") ||
                user.User_account.Length < 5 ||
                user.User_account.Length > 64 )
            {
                result = false;
            }
            String user_password = user.User_password;
            // 用户密码不能为空，不能不写，长度不能不等于32，传进来的时候就应该是加密过的
            if (user_password == null || user_password.Equals("") || user.User_password.Length != 32)
            {
                result = false;
            }
            // 最后登录ip不能为空，也不能不写，长度不能大于64，不能小于8
            // 0.0.0.0. —— 8
            if (user.User_last_login_ip == null || user.User_last_login_ip.Equals("") ||
                user.User_last_login_ip.Length > 64 || user.User_last_login_ip.Length < 8 )
            {
                result = false;
            }
            // 头像不能为空， 不能不写，长度不能大于256
            if (user.User_head == null || user.User_head.Equals("")
                || user.User_head.Length > 256)
            {
                result = false;
            }
            // 昵称不能为空，不能不写，长度不能小于1，不能大于32
            if (user.User_nickname == null || user.User_nickname.Equals("") || user.User_nickname.Length < 1 ||
                user.User_nickname.Length > 32)
            {
                result = false;
            }
            //余额不能小于0
            if (user.User_money < 0.0f)
            {
                result = false;
            }
            //如有自我介绍，则自我介绍长度不能大于256
            if (user.User_introduction != null && user.User_introduction.Length > 256)
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
            if (isLegalNewUser(user))
            {
                /*
                    添加用户，数据库中有userAccount唯一约束，因此这里加上异常处理
                 */
                try
                {
                    UserData UserData_Create = UserData.GetNewInstance();
                    res = UserData_Create.CreateUser(user);
                    SendVerifyMailToNewUser(user);
                }
                catch (Exception)
                {
                    res = 0;
                }
               
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
        /// <summary>
        /// 根据账号和密码获得用户信息，返回一个符合查询条件的User，若不存在，返回null
        /// 其中参数的Account和Password必填
        /// </summary>
        /// <param name="user">要获得的User类，其中Account和Password必须填</param>
        /// <returns>User类或null</returns>
         public static User GetUserByAccountAndPassword(User user)
         {
             User ResultUser = null;
             /*
              * 数据完整性检查
              * */
             UserData UserData_Get = UserData.GetNewInstance();
             ResultUser = UserData_Get.GetUserByAccountAndPassword(user);
             return ResultUser;
         }
        /// <summary>
        /// 取回密码函数，成功返回true，否则返回false
        /// </summary>
        /// <param name="user">重设密码的User类，Account必填</param>
        /// <returns>成功返回true，否则返回false</returns>
 
        public static Boolean GetForgetPassword(User user)
         {

             Boolean result = false;
             UserData userData = UserData.GetNewInstance();

             if (user.User_account == null || //不为null
                 user.User_account.Equals("") || //不为空
                 user.User_account.Length > 64)
             {//不长于64
                 // 数据验证完毕
                 result = false;
             }
             else
             {
                 //调用DAL重设密码
                String newUserPassword = GenerateRandomString(8);// 生成8位新密码，包括大小写特殊字符等等等等
                user.User_password = MD5(newUserPassword); //加密后传入数据库
                if (userData.GetForgetPassword(user)) //数据库那边搞定了！~
                {
                    result = true;
                    //给用户发邮件
                    SendNewPasswordMailToUser(user, newUserPassword);
                }
                else
                {
                    result = false;
                }
             }
             return result;
         }
        /// <summary>
        /// 检查参数中的User类实例是否可以作为合法的登录用户信息
        /// </summary>
        /// <param name="user">要检查的User类</param>
        /// <returns>合法返回true，否则false</returns>
        private static Boolean isLegalLoginInfo(User user)
        {
            Boolean result = true;
            if (user.User_account == null ||
                user.User_account.Equals("") ||
                user.User_account.Length > 64)
                result = false;
            if (user.User_password == null ||
                user.User_password.Length != 32 ||  //其实这不太可能，只判断是否等于32就好了，因为到BLL的全MD5过
                user.User_password.Equals(""))
                result = false;

            return result;
        }
        /// <summary>
        /// 判断用户登录是否合法，合法返回登录用户对应的User对象，非法返回null
        /// User对象的Account Password必填
        /// </summary>
        /// <param name="user">需要判断的User对象</param>
        /// <returns>User类的实例</returns>
        public static User isLegalLogin(User user)
        {
            /*
                数据合法性检查
             */
            if (!isLegalLoginInfo(user))
                return null;
            else
            {
                /*操作数据库*/
                try
                {
                    UserData userData = UserData.GetNewInstance();
                    User entireUser = userData.GetUserByAccountAndPassword(user);
                    return entireUser;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 判断用户是否已经登录，如果登录那么返回包含用户信息的User对象，否则返回Null，相当于认证
        /// </summary>
        /// <param name="httpRequest">当前的httpRequest</param>
        /// <returns>已登录返回User对象，否则返回Null</returns>
        public static User isLogged(HttpRequest httpRequest)
        {
            /* 输入验证不可少 */
            /* 账号密码输入验证 */
            if (httpRequest.Cookies["userAccount"] == null
                || httpRequest.Cookies["userPassword"] == null
                || httpRequest.Cookies["userAccount"].Value.Length > 64
                || httpRequest.Cookies["userPassword"].Value.Length != 32
                )
                return null;
            else
            {
                User logUser = new User();
                logUser.User_account = httpRequest.Cookies["userAccount"].Value;
                logUser.User_password = httpRequest.Cookies["userPassword"].Value;
                //这个调用必须指定ip
                logUser.User_last_login_ip = HttpContext.Current.Request.UserHostAddress;
                logUser.User_last_login_date = DateTime.Now;
                User detailUser = isLegalLogin(logUser);
                return detailUser;
            }
        }
        /// <summary>
        /// BAL修改用户密码，包括数据检验，成功返回true否则返回false
        /// </summary>
        /// <param name="user">要修改的用户</param>
        /// <param name="newPassword">新密码，应为32位MD5大写字符串</param>
        /// <returns>成功返回true否则false</returns>
        public static Boolean ChagneUserPassword(User user, String newPassword)
        {
            Boolean result = true;
            if (newPassword.Length != 32) //新密码长度检验
                result = false;
            if (!isLegalNewUser(user))
                result = false;
            UserData userData = UserData.GetNewInstance();
            result =  userData.ChangeUserPassword(user, newPassword);
            return result;
        }
        /// <summary>
        /// 更新用户信息，会有isLegalLoginInfo检查的。成功返回true否则返回false
        /// </summary>
        /// <param name="user">要更新的user信息</param>
        /// <returns>成功返回true否则返回false</returns>
        public static Boolean UpdateUserInfo(User user)
        {
            Boolean result = true;
            /* 数据检验 */
            if (!isLegalNewUser(user))
            {
                result = false;
            }
            else
            {
                UserData userData = UserData.GetNewInstance();
                result = userData.UpdateUserInfo(user);
            }
            return result;
        }
        /// <summary>
        /// 激活用户，激活成功返回true，激活失败返回false
        /// </summary>
        /// <param name="user">要激活的，包含完整信息的User类</param>
        /// <param name="verifyCode">页面接受的验证码</param>
        /// <returns>激活成功返回ture，激活失败返回false</returns>
        public static Boolean CheckUser(User user, Guid verifyCode)
        {
            Boolean result = true;
            if (!isLegalNewUser(user))
            {
                result = false;
            }
            //这里的数据检查比较麻烦。
            if (user.User_verify_code == null
                || verifyCode == null
                || user.User_isChecked == true)
            {
                result = false;
            }
            else
            {
                if (user.User_verify_code == verifyCode)
                {
                    user.User_isChecked = true;
                    UserData userData = UserData.GetNewInstance();
                    result = userData.UpdateUserInfo(user);
                }
                else
                {
                    result = false;
                }
            }

            return result;

        }
    }
}