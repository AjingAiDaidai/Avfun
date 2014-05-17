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
        /// 将BLL层传递过来的UI.User对象转换为Enitity映射中的USER对象，所有属性拷贝
        /// </summary>
        /// <param name="user">UI.User对象，由BLL层传递</param>
        /// <returns>转换完毕的USER对象</returns>
        private USER CovertUserToUSER(User user)
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
            USER NewUSER = this.CovertUserToUSER(user);
            DataEntity.USER.AddObject(NewUSER);
            res = DataEntity.SaveChanges();
            return res;
        }

        public int InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        public USER[] GetUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserByID(User user)
        {
            throw new NotImplementedException();
        }
    }
}