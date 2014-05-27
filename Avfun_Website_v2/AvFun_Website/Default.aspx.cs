using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Avfun_BLL;
using Avfun_UI;
namespace AvFun_Website
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //查看是否授权
            IUserBLL userBLL = BLLFactory.CreateInstance<IUserBLL>("UserBLL");
            User loggedUser = userBLL.isLogged(Request);
            if (!Page.IsPostBack)
            {
                //用户第一次访问
                if (loggedUser != null)
                { //登录的用户
                    loggedUserNickname.Text = loggedUser.User_nickname;
                    unloginDiv.Visible = false; //未登录图层隐藏
                    loginDiv.Visible = true; //登录图层开启
                }
                else
                {  //如果未登录
                    loginDiv.Visible = false; //登录图层隐藏
                    unloginDiv.Visible = true; //未登录图层开启
                }
            }
            else
            {
                //用户点击登出按钮
                /*
                Request.Cookies.Remove("userAccount");
                Request.Cookies.Remove("userPassword");
                 * 这么删除是错的
                 */

                //删除user cookie
                HttpCookie userAccountCookie = new HttpCookie("userAccount");
                userAccountCookie.Expires = DateTime.Now.AddDays(-1D);
                Response.Cookies.Add(userAccountCookie);
                //删除password cookie
                HttpCookie userPasswordCookie = new HttpCookie("userPassword");
                userPasswordCookie.Expires = DateTime.Now.AddDays(-1D);
                Response.Cookies.Add(userPasswordCookie);

                 loginDiv.Visible = false; //登录图层隐藏 
                 unloginDiv.Visible = true; //未登录图层开启
            }
        }
    }
}