using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using AvFun_Website.AvFun_UI;
using AvFun_Website.Avfun_BLL;

namespace AvFun_Website.user_pages
{
    public partial class user_changeinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断是否已经登录，注意，由于这里不管是不是postBack，因此取到的对象，timeStamp一定是最新的那个！
            //换而言之，我们的策略就是LastComesWin——最新的一次提交总是屌的！
            User loggedUser = UserOpr.isLogged(Request);
            //未登录 
            if (loggedUser == null)
            {
                //登录界面不显示
                loggedDiv.Visible = false;
                //提示信息
                logStatus.Text = "主人大人，您未登录或已经登录过期哦！3秒后自动转向登录页面哦！请登录了再来调戏人家啦";
                logStatus.Visible = true; //提示信息开启

                //重定向
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=" + ReadWebConfig.GetAppSettingValue("LoginPageURL"); //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
            else //已登录 
            {
                //显示登录界面
                loggedDiv.Visible = true;
                //提示信息隐藏
                logStatus.Visible = false;

                if (!Page.IsPostBack)
                {
                    //用户未提交修改信息

                    //设置页面中对应的用户信息
                    //账户
                    txtUserAccount.Text = loggedUser.User_account;
                    //余额
                    lblMoney.Text = lblMoney.Text + loggedUser.User_money.ToString();
                    //头像，记得去空格
                    imgHead.ImageUrl = loggedUser.User_head.Trim();
                    //简介，记得去空格
                    txtUserIntroduction.Text = loggedUser.User_introduction.Trim();
                    //昵称。记得去空格
                    txtUserNickname.Text = loggedUser.User_nickname.Trim();
                    if (loggedUser.User_sex) //男生
                    {
                        UserSex.Items[0].Selected = true;
                        UserSex.Items[1].Selected = false;
                    }
                    else
                    {
                        UserSex.Items[0].Selected = false;
                        UserSex.Items[1].Selected = true; //女生
                    }
                }
                else
                {
                    //用户提交修改信息，验证的时候注意，从loggedUser里取账号和旧密码，旧密码和输入比对，账号直接带入操作
                    String oldPassword = Request.Form["txtUserOldPassword"];
                    String newPassword = Request.Form["txtUserNewPassword"];
                    String verifyNewPassword = Request.Form["txtUserVerifyNewPassword"];
                    String userIntroduction = Request.Form["txtUserIntroduction"].Trim();
                    String userNickname = Request.Form["txtUserNickName"].Trim(); //记得去空格
                    //头像！这里用完记得立刻释放掉Cookie
                    String userHead = Request.Cookies["userHead"].Value;

                    //转换为布尔型，注意用户性别1为男0为女
                    String strUserSex = Request.Form["UserSex"].Trim();
                    Boolean userSex = strUserSex.ToUpper().Trim().Equals("MALE");

                    User newInfoUser = new User(loggedUser);
                    #region 验证是否需要修改密码
                    if (!oldPassword.Equals("")
                        && oldPassword != null)
                    //填写了旧密码，意味着要修改密码
                    {
                        if (!newPassword.Equals(verifyNewPassword)) //新密码与确认密码不匹配
                        {
                            lblChangePasswordStatus.Text = "新密码与确认密码不匹配，请检查后再输入";
                            lblChangePasswordStatus.Visible = true;
                            return; //停止提交
                        }
                        else
                        {
                            if (!UserOpr.MD5(oldPassword).Equals(loggedUser.User_password))
                            {
                                //旧密码与账号密码不匹配
                                lblChangePasswordStatus.Text = "旧密码输入错误，请重新输入";
                                lblChangePasswordStatus.Visible = true;
                                return; //停止提交
                            }
                            else
                            {
                                //旧密码与账号密码匹配，且新密码与确认密码匹配的情况下
                                if (newPassword.Length > 16
                                    || newPassword.Length < 6)
                                {
                                    //新密码长度不对
                                    lblChangePasswordStatus.Text = "新密码长度不正确，请重新提交";
                                    lblChangePasswordStatus.Visible = true;
                                    return; //停止提交
                                }
                                else
                                {
                                    //修改后一并提交
                                    newInfoUser.User_password = UserOpr.MD5(newPassword);
                                    /*
                                    //修改用户密码
                                    if (UserOpr.ChagneUserPassword(newInfoUser, UserOpr.MD5(newPassword)))
                                    {
                                        //更改成功
                                        lblChangePasswordStatus.Text = "修改密码成功，请重新登录";
                                        lblChangePasswordStatus.Visible = true;
                                        return;//停止提交
                                    }
                                    else
                                    {
                                        //更改失败
                                        lblChangePasswordStatus.Text = "修改密码失败，请检查输入是否正确";
                                        lblChangePasswordStatus.Visible = true;
                                        return; //停止提交
                                    }
                                     * */
                                }

                            }
                        }
                    }
                    #endregion

                    #region 修改用户信息，这里不用加验证，userOpr里有

                    newInfoUser.User_introduction = userIntroduction;
                    newInfoUser.User_nickname = userNickname;
                    if (userHead != null) 
                    {
                        newInfoUser.User_head = userHead; //这里注意看一下是相对路径还是绝对路径
                        //释放Cookie
                        HttpCookie userHeadCookie = new HttpCookie("userHead");
                        userHeadCookie.Expires = DateTime.Now.AddDays(-1D);
                        Response.Cookies.Add(userHeadCookie);
                    }

                    newInfoUser.User_sex = userSex;
                    #endregion


                    //开始调用BLL
                    if (UserOpr.UpdateUserInfo(newInfoUser))
                    {
                        //修改成功
                        logStatus.Text = "资料修改成功了哦，3秒后回到用户主页哦";
                        logStatus.Visible = true;
                        loggedDiv.Visible = false;
                        //重定向
                        HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                        RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                        RedirectMeta.Content = "3;url=user_index.aspx"; //时间为三秒，跳转到首页
                        this.Page.Header.Controls.Add(RedirectMeta);

                    }
                    else
                    {
                        //修改失败，给出提示信息
                        logStatus.Text = "修改资料失败了呢，真是抱歉，是不是主人大人什么地方填错了呢？";
                        logStatus.Visible = true;
                    }

                }
            }
        }
    }
}