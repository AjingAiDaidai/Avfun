using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AvFun_Website.AvFun_UI;
namespace AvFun_Website.Avfun_DAL
{
    public class UserData : IUserData
    {

        /// <summary>
        /// 将DAL的USER类转换成BLL的User类
        /// </summary>
        /// <param name="user">要转换的USER类</param>
        /// <returns>转换后对应的user类</returns>
        private User ConvertUSERToUser(USER user)
        {
            User ResultUSER = new User();
 
            //这行代码不要的原因是因为U_id无意义啊！           ResultUSER.U_id = user.u_id;
            ResultUSER.User_id = user.user_id;
            ResultUSER.User_head = user.user_head;
            ResultUSER.User_account = user.user_account;
            ResultUSER.User_introduction = user.user_introduction;
            ResultUSER.User_isChecked = user.user_isChecked;
            ResultUSER.User_isDeleted = user.user_isDeleted;
            ResultUSER.User_last_login_ip = user.user_last_login_ip;
            ResultUSER.User_last_login_date = user.user_last_login_time;
            ResultUSER.User_money = user.user_money;
            ResultUSER.User_nickname = user.user_nickname;
            ResultUSER.User_password = user.user_password;
            ResultUSER.User_sex = user.user_sex;
            ResultUSER.User_timestamp = user.user_timestamp;
            ResultUSER.User_verify_code = user.user_verify_code;
            return ResultUSER;
        }
        /// <summary>
        /// 将BLL层传递过来的UI.User对象转换为Enitity映射中的USER对象，所有属性拷贝
        /// </summary>
        /// <param name="user">UI.User对象，由BLL层传递</param>
        /// <returns>转换完毕的USER对象</returns>
        private USER ConvertUserToUSER(User user)
        {
            USER ResultUSER = new USER();
            ResultUSER.u_id = user.U_id;
            ResultUSER.user_id = user.User_id;
            ResultUSER.user_head = user.User_head;
            ResultUSER.user_account = user.User_account;
            ResultUSER.user_introduction = user.User_introduction;
            ResultUSER.user_isChecked = user.User_isChecked;
            ResultUSER.user_isDeleted = user.User_isDeleted;
            ResultUSER.user_last_login_ip = user.User_last_login_ip;
            ResultUSER.user_last_login_time = user.User_last_login_date;
            ResultUSER.user_money = user.User_money;
            ResultUSER.user_nickname = user.User_nickname;
            ResultUSER.user_password = user.User_password;
            ResultUSER.user_sex = user.User_sex;
            ResultUSER.user_timestamp = user.User_timestamp;
            ResultUSER.user_verify_code = user.User_verify_code;
            return ResultUSER;
        }
        /// <summary>
        /// 注册新用户，无数据验证，数据验证应该在BLL层完成
        /// </summary>
        /// <param name="user">需要新创建的UI.User类</param>
        /// <returns>影响的行数，大于0说明成功</returns>
        public int CreateUser(User user)
        {
            int res;
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            USER NewUSER = this.ConvertUserToUSER(user);
            DataEntity.USER.AddObject(NewUSER);
            res = DataEntity.SaveChanges();
            return res;
        }

        public int InsertUser(User user)
        {
            return CreateUser(user);
        }

        public USER[] GetUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserByID(User user)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// DAL层，根据用户账号密码返回相应信息
        /// </summary>
        /// <param name="user">要查询的UI.User类，账号密码必填</param>
        /// <returns>若存在返回对应的User类，保存了全部信息，否则返回null</returns>
        public User GetUserByAccountAndPassword(User user)
        {
            User ResultUser = null;
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            USER LoginUser = (from usr in DataEntity.USER
                             where usr.user_account == user.User_account
                             && usr.user_password == user.User_password
                              select usr)
                             .Single();
            ResultUser = ConvertUSERToUser(LoginUser);
            return ResultUser;
        }
        /// <summary>
        /// DAL层重设密码函数，成功返回true，否则返回false
        /// </summary>
        /// <param name="user">要改变密码的user,account必填,password必填，为重新生成的密码</param>
        /// <returns>成功返回true，否则false</returns>
        public Boolean GetForgetPassword(User user)
        {
            Boolean result = false;
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();

                try
                {
                    USER DestUser = (from usr in DataEntity.USER
                             where usr.user_account == user.User_account //找目标user，LINQ里面字符串相等就是 ==!
                             select usr).Single();
                    DestUser.user_password = user.User_password; //更改密码为新生成的8位随机字符串
                    DataEntity.SaveChanges(); 
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }

            return result;
        }

        /// <summary>
        /// 更新用户登陆后的信息，ip啊,datetime之类的
        /// </summary>
        /// <param name="user">要更新的user类</param>
        public Boolean UpdateLogInformation(User user)
        {
            Boolean result = false;
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            try
            {
                USER loggedUSER = (from usr in DataEntity.USER
                                   where usr.user_account == user.User_account
                                   && usr.user_password == usr.user_password
                                   select usr).Single();
                loggedUSER.user_last_login_ip = user.User_last_login_ip;
                loggedUSER.user_last_login_time = user.User_last_login_date;
                DataEntity.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        //方便以后做成单例模式
        public static UserData GetNewInstance()
        {
            return new UserData();
        }
    }
}