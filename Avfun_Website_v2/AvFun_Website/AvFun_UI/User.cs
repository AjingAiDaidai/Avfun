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
        #region 属性和accessor
        /* 注意，在该类中我们没有考虑timestamp
         * 因为数据的并发问题不是我们在UI层考虑的问题，这个问题交给了DAL
         */
        private double user_money;

        public double User_money
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
        #endregion
        #region 构造函数
        public User()
        {
        }
        /// <summary>
        /// 为了拷贝其他实例的构造函数
        /// </summary>
        /// <param name="user">要拷贝的实例</param>
        public User(User user)
        {
           
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
            this.user_timestamp = user.User_timestamp;
            //TimeStamp没改。
        }
        /// <summary>
        /// 主要是为注册提供的构造函数，注意，没提供时间戳！
        /// </summary>
        /// <param name="account">账号，必填</param>
        /// <param name="password">密码，必填，必须是MD5加密后的</param>
        /// <param name="nickname">昵称，必填</param>
        /// <param name="sex">性别，默认为true，男生</param>
        /// <param name="head">头像，有默认头像</param>
        /// <param name="isDeleted">是否删除，默认未删除</param>
        /// <param name="isChecked">是否激活，默认未激活</param>
        /// <param name="last_login_date">最后登录时间，默认取服务器当前时间</param>
        /// <param name="last_login_ip">最后登录IP，默认取空:""</param>
        /// <param name="money">金额，默认取0</param>
        /// <param name="introduction">简介，默认取null</param>
        /// <param name="verify_code">发给用户要求激活的激活码，自动生成，可以不写</param>
        /// <param name="U_ID">无意义的自增长用户id</param>
        /// <param name="USER_ID">用户主键，USER_ID</param>
        public User(String account, String password, String nickname,
                    Boolean sex = true, //默认是男生
                    String last_login_ip = null, //最后登录ip
                    String head = "img/01.jpg", //默认头像
                    Boolean isDeleted = false, //默认没删除
                    Boolean isChecked = false,  //默认未激活
                    DateTime last_login_date = new DateTime(),
                    float    money = 0.0f,
                    String   introduction = null,
                    Guid     verify_code = new Guid(),
                    int      U_ID = 0,              //名称冲突，所以大写
                    Guid     USER_ID = new Guid()  //名称冲突，所以大写
            )
        {
            //此项不能是DateTime否则是0000-00-00
            last_login_date = DateTime.Now;
            //此项不能是new GUID()否则是0000000000-0000000000000000
            verify_code = Guid.NewGuid();
            //同理
            USER_ID = Guid.NewGuid();

            this.user_account = account;
            this.user_password = password.ToUpper();
            this.user_nickname = nickname;
            this.user_sex = sex;
            this.user_head = head;
            this.user_isDeleted = isDeleted;
            this.user_isChecked = isChecked;
            this.user_last_login_date = last_login_date;
            this.user_last_login_ip = last_login_ip;
            this.user_money = money;
            this.user_introduction = introduction;
            this.user_verify_code = verify_code;
            this.u_id = U_ID;
            this.user_id = USER_ID;
        }
        #endregion
    }
}