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
        private USER CovertUserToUSER(User user)
        {
            ///<summary>
            ///将UI的User对象转换为USER对象
            ///同名字段完全拷贝
            ///没有数据验证
            ///</summary>
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
        public int CreateUser(User user)
        {
            ///<summary>
            ///调用存储过程向USER表添加新用户
            ///这里调用的时候。user的user_id,和timestamp应该为null
            ///</summary>
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            int EffectRowsNumber = -1; //影响的行数
            EffectRowsNumber = DataEntity.CreateNewUser(user.User_account,  //账号，在这里不做数据验证
                                            user.User_password, //密码
                                            user.User_nickname, //昵称
                                            user.User_sex, //性别
                                            user.User_head, //头像
                                            user.User_isDeleted, //是否删除
                                            user.User_isChecked, //是否激活
                                            user.User_last_login_date, //最后登录日期
                                            user.User_last_login_ip, //最后登录ip
                                            user.User_money, //用户金额
                                            user.User_introduction); //用户简介
           
            return EffectRowsNumber;
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