using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*  管理员类
 *  Author: LU YuXun 2014/5/13
 *  Version: 1
 *  Reference:http://msdn.microsoft.com/en-us/library/ms131092.aspx
 *  Update notes:
 *  NULL.UP-TO-DATE.
 *  
 *  注意：这里有很多属性（isDeleted啦，isChecked啦）都是冗余的（蛋，这是我设计上的一个失败），在传到DAL层的时候请务必注意这一点。
 */
namespace AvFun_Website.AvFun_UI
{
    public class Admin:GeneralUser
    {
        public override int U_id
        {
            get { return this.u_id; }
        }

        public override Guid User_id
        {
            get
            {
                return this.user_id;
            }
            set
            {
                this.user_id = value;
            }
        }

        public override String User_account
        {
            get
            {
                return this.user_account;
            }
            set
            {
                this.user_account = value;
            }
        }

        public override String User_password
        {
            get
            {
                return this.user_password;
            }
            set
            {
                this.user_password = value;
            }
        }

        public override String User_nickname
        {
            get
            {
                return this.user_nickname;
            }
            set
            {
                this.user_nickname = value;
            }
        }

        public override bool User_sex
        {
            get
            {
                return this.user_sex;
            }
            set
            {
                this.user_sex = value;
            }
        }

        public override String User_head
        {
            get
            {
                return this.user_head;
            }
            set
            {
                this.user_head = value;
            }
        }

        public override bool User_isDeleted
        {
            get
            {
                return this.user_isDeleted;
            }
            set
            {
                this.user_isDeleted = value;
            }
        }

        public override bool User_isChecked
        {
            get
            {
                return this.user_isChecked;
            }
            set
            {
                this.user_isChecked = value;
            }
        }

        public override DateTime User_last_login_date
        {
            get
            {
                return this.user_last_login_date;
            }
            set
            {
                this.user_last_login_date = value;
            }
        }

        public override String User_last_login_ip
        {
            get
            {
                return this.user_last_login_ip;
            }
            set
            {
                this.user_last_login_ip = value;
            }
        }
        public Admin()
        {
        }
        public Admin(Admin admin)
        {
            //因为隐式调用的时候，调用的永远都是父类的【无参】构造函数，所以可以这么玩儿。
            this.u_id = admin.U_id;
            this.user_id = admin.User_id;
            this.user_account = admin.User_account;
            this.user_password = admin.User_password;
            this.user_nickname = admin.User_nickname;
            this.user_sex = admin.User_sex;
            this.user_head = admin.User_head;
            this.user_isDeleted = admin.User_isDeleted;
            this.user_isChecked = admin.User_isChecked;
            this.user_last_login_date = admin.User_last_login_date;
            this.user_last_login_ip = admin.User_last_login_ip;
            this.user_timestamp = admin.User_timestamp;
        }
        public Admin(String account, String password, String nickname, Boolean sex, String head, String introduction)
        {
            //因为隐式调用的时候，调用的永远都是父类的【无参】构造函数，所以可以这么玩儿。
            this.user_password = password;
            this.user_account = account;
            this.user_nickname = nickname;
            this.user_sex = sex;
            this.user_head = head;
        }
    }
}