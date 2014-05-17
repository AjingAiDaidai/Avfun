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
        /// 向新注册的用户发送激活账户的邮件，返回值大于0说明发送成功
        /// public的原因是因为，重发确认信功能中也要用到
        /// </summary>
        /// <param name="newUser">刚刚创建的用户对应的UI.User实例</param>
        /// <returns>返回值大于0说明发送成功</returns>
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
        /// 注册时用户类的数据完整性检查，其实更改的时候也用得到啦！
        /// </summary>
        /// <param name="user">要检查的用户类</param>
        /// <returns>Boolean，true为合法，false为非法</returns>
        private static Boolean isLegalNewUser(User user)
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
    }
}