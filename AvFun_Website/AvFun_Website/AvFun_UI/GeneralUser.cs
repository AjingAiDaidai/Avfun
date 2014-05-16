using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*  抽象用户类
 *  Author: LU YuXun 2014/5/13
 *  Version: 1
 *  Reference:http://msdn.microsoft.com/en-us/library/ms131092.aspx
 *  Update notes:
 *  NULL.UP-TO-DATE.
 */
namespace AvFun_Website.AvFun_UI
{
    public abstract class GeneralUser
    {
        /// <summary>
        /// 无意义自增长ID字段
        /// </summary>
        protected int u_id;

        public abstract int U_id
        {
            get;
        }
        /// <summary>
        /// 用户主键，uniqueidentifer，数据库自己生成
        /// </summary>
        protected Guid user_id;

        public abstract Guid User_id
        {
            get;
            set;
        }
        /// <summary>
        /// 用户登录名，长64
        /// </summary>
        protected String user_account;

        public abstract String User_account
        {
            get;
            set;
        }
        /// <summary>
        /// 用户密码，全大写32位MD5
        /// </summary>
        protected String user_password;

        public abstract String User_password
        {
            get;
            set;
        }
        /// <summary>
        /// 用户昵称，长32
        /// </summary>
        protected String user_nickname;

        public abstract String User_nickname
        {
            get;
            set;
        }
        /// <summary>
        /// 用户性别，0女1男
        /// </summary>
        protected Boolean user_sex;

        public abstract Boolean User_sex
        {
            get;
            set;
        }
        /// <summary>
        /// 用户头像，长256
        /// </summary>
        protected String user_head;

        public abstract String User_head
        {
            get;
            set;
        }
        /// <summary>
        /// 用户是否被删除
        /// </summary>
        protected Boolean user_isDeleted;

        public abstract Boolean User_isDeleted
        {
            get;
            set;
        }
        /// <summary>
        /// 用户是否激活
        /// </summary>
        protected Boolean user_isChecked;

        public abstract Boolean User_isChecked
        {
            get;
            set;
        }
        /// <summary>
        /// 用户最后登录日期
        /// </summary>
        protected DateTime user_last_login_date;

        public abstract DateTime User_last_login_date
        {
            get;
            set;
        }
        /// <summary>
        /// 用户最后登录IP，长64
        /// </summary>
        protected String user_last_login_ip;

        public abstract String User_last_login_ip
        {
            get;
            set;
        }
        /// <summary>
        /// 时间戳
        /// </summary>
        protected byte[] user_timestamp;

        public byte[] User_timestamp
        {
            get { return user_timestamp; }
            set { user_timestamp = value; }
        }
    }
}