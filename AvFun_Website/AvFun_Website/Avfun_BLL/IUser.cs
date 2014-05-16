using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AvFun_Website.AvFun_UI;
namespace AvFun_Website.Avfun_BLL
{
    interface IUser : IGeneralUser
    {
        /// <summary>
        /// 根据形式参数中user的id返回完整的User对象
        /// </summary>
        /// <param name="user">用于查找完整信息的UI.User类实例，只需填写user_id字段即可</param>
        /// <returns>User类，其中包括对应的user的完整信息</returns>
        User GetUserByID(User user);
        /// <summary>
        /// 新建用户账号
        /// </summary>
        /// <param name="user">新建的用户账号，其中user_id，u_id,user_verify_code不用写。</param>
        /// <returns>影响的行数</returns>
        int CreateUser(User user); //创建用户
    }
}
