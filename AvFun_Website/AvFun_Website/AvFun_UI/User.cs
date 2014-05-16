using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*  用户类
 *  Author: LU YuXun 2014/5/13
 *  Version: 1
 *  Reference:http://msdn.microsoft.com/en-us/library/ms131092.aspx
 *  Update notes:
 *  NULL.UP-TO-DATE.
 */
namespace AvFun_Website.AvFun_UI
{
    [Serializable]
    public class User:GeneralUser
    {
        /* 注意，在该类中我们没有考虑timestamp
         * 因为数据的并发问题不是我们在UI层考虑的问题，这个问题交给了DAL
         */
        private float user_money;

        public float User_money
        {
            get { return user_money; }
            set { user_money = value; }
        }
        private String user_introduction;

        public String User_introduction
        {
            get { return user_introduction; }
            set { user_introduction = value; }
        }
        private Guid user_verify_code;

        public Guid User_verify_code
        {
            get { return user_verify_code; }
            set { user_verify_code = value; }
        }
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
                //注意，set方法使用隐函数value，value的类型与设置的字段类型一致。校验什么的可以考虑加在这里
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
                //这里有一个问题，我们没为user_account设置缓冲区耶，在构造函数里分配好了。
                //上面那条注释已被解决，解决方法是利用抽象类构造函数。
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

        public User()
        {
        }
        public User(User user)
        {
            //因为隐式调用的时候，调用的永远都是父类的【无参】构造函数，所以可以这么玩儿。
            this.u_id = user.U_id;
            this.user_id = user.User_id;
            this.user_account = user.User_account;
            this.user_password = user.User_password;
            this.user_nickname = user.User_nickname;
            this.user_sex = user.User_sex;
            this.user_head = user.User_head;
            this.user_isDeleted = user.User_isDeleted;
            this.user_isChecked = user.User_isChecked;
            this.user_last_login_date = user.User_last_login_date;
            this.user_last_login_ip = user.User_last_login_ip;
            this.user_money = user.User_money;
            this.user_introduction = user.User_introduction;
            this.user_verify_code = user.User_verify_code;
            //TimeStamp没改。
        }
        public User(String account, String password, String nickname, Boolean sex, String head, String introduction)
        {
            //因为隐式调用的时候，调用的永远都是父类的【无参】构造函数，所以可以这么玩儿。
            this.user_password = password;
            this.user_account = account;
            this.user_nickname = nickname;
            this.user_sex = sex;
            this.user_head = head;
            this.user_introduction = introduction;
        }

    }
}