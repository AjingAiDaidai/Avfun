using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AvFun_Website.AvFun_UI;
using AvFun_Website.Avfun_DAL;
namespace AvFun_Website.Avfun_BLL
{
    public class UserOpr : IUser
    {

        public User GetUserByID(User user)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// BLL层创建用户账号，由UI层调用，负责调用DAL层同名函数
        /// </summary>
        /// <param name="user">要创建的账号类，u_id,user_id,user_verify_code可以不填</param>
        /// <returns>int值，影响的行数，大于0说明操作成功</returns>
        public int CreateUser(User user)
        {
            /*
                数据完整性检查
             */
            /*
                数据补充
             */
            user.User_last_login_ip = "127.0.0.1";
            user.User_last_login_date = DateTime.Now;
            user.User_isChecked = false;
            user.User_isDeleted = false;
            user.User_money = 0.0f;
            /*
                添加用户
             */
            UserData UserData_Create = new UserData();
            int num = UserData_Create.CreateUser(user);
            return num;
        }
    }
}