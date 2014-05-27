using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Avfun_UI;
using Avfun_BLL;
namespace AvFun_Website
{
    public partial class NewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IUserBLL userBLL = BLLFactory.CreateInstance<IUserBLL>("UserBLL");
            if (!Page.IsPostBack)
            {
                //第一次打开该页面
                //View处理部分：
                RegResult.Visible = false; //注册结果不可见。
                RegUser.Visible = true;  //显示注册表单
            }
            else
            {
                    //用户填写好了表单，回传到了本页。
                    #region Control处理部分
                    //获取提交表单的信息，去掉所有前导和滞后空格
                    String userAccount = Request.Form["UserAccount"].Trim();
                    String userPassword = Request.Form["UserPassword"]; //密码不用去空格
                    if (userPassword.Length < 6 || userPassword.Length > 16)
                    {
                        RegResult.Text = "密码长度应该在6-16位之间，请重新输入";
                        RegResult.Visible = true;
                        return;
                    }
                    String strUserSex = Request.Form["UserSex"].Trim();
                    String userIntroduction = Request.Form["UserIntroduction"].Trim();
                    String userNickname = Request.Form["UserNickname"].Trim();
                    //用户验证码
                    String regVerifyCode = Request.Form["RegVerifyCode"].Trim().ToUpper();
                    //最后一次登录IP即为注册IP.
                    String userLastLoginIp = HttpContext.Current.Request.UserHostAddress;

                    //转换为布尔型，注意用户性别1为男0为女
                    Boolean userSex = strUserSex.ToUpper().Trim().Equals("MALE");

                    //密码MD5加密
                    userPassword = userBLL.MD5(userPassword);
                    //测试用语句
                    /* RegResult.Text =
                        "注册信息为：" + "账号" + userAccount + "密码" + userPassword + "性别" + strUserSex +
                        "密码" + userPassword + "昵称" + userNickname + "最后登录ip" + userLastLoginIp + "个人说明" + userIntroduction;
                     */
                    if ( //验证码判定
                        Session[RegVerifyCodeGenerator.strIdentify] != null
                        && regVerifyCode.ToUpper().Equals
                        (Session[RegVerifyCodeGenerator.strIdentify].ToString().ToUpper() )
                        && !regVerifyCode.Equals("")
                        && regVerifyCode != null 
                       )
                    {
                        //验证码正确，这里记得刷新验证码以防后退提交！
                        Session.Remove(RegVerifyCodeGenerator.strIdentify); //防止后退提交
                        #region 用户注册，与userBLL打交道
                        //开始注册用户，数据完整性检查在BLL.userBLL类中
                        String user_head = "img/01.jpg"; //男生默认头像
                        if (userSex == false) //是女生
                            user_head = "img/00.jpg"; //女生默认头像

                        User newUser = new User(userAccount, userPassword, userNickname, userSex, userLastLoginIp,user_head.Trim());
                        newUser.User_introduction = userIntroduction;

                        if (userBLL.CreateUser(newUser) > 0)
                        {
                            RegResult.Text = "注册成功！请到您的邮箱" + userAccount + "中打开确认信完成激活，3秒钟之后自动跳转回主页";
                            RegUser.Visible = false; //注册表单不可见
                            HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                            RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                            RedirectMeta.Content = "3;url=" + ReadWebConfig.GetAppSettingValue("Domain") ; //时间为三秒，跳转到首页
                            this.Page.Header.Controls.Add(RedirectMeta);
                        }
                        else
                        {
                            RegResult.Text = "注册失败！请检查输入项！";

                            RegUser.Visible = true; //注册表单可见
                        }
                        #endregion
                    }
                    else //验证码输入不正确
                    {
                        RegResult.Text = "验证码验证出错"; //提示状态
                        RegUser.Visible = true; //注册表单可见
                    }

                    #endregion
                    #region 通用View处理部分
                    RegResult.Visible = true; //提示状态
                    UserPassword.Text = ""; //清空密码框
                    #endregion
            }
        }
    }
}