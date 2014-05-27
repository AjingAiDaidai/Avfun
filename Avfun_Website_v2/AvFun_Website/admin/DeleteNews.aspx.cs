using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Avfun_BLL;
using Avfun_UI;
namespace AvFun_Website.admin
{
    public partial class DeleteNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            INewsBLL newsBLL = BLLFactory.CreateInstance<INewsBLL>("NewsBLL");
            IAdminBLL adminBLL = BLLFactory.CreateInstance<IAdminBLL>("AdminBLL");
            Admin loggedAdmin = adminBLL.isLogged(Request);
            if ( loggedAdmin == null )
            {
                //未登录
                //未登录
                lblLoginStatus.Text = "您未登录或已经登录过期，请重新登录，3秒后转回管理员登录页。";
                lblLoginStatus.Visible = true;
                AdminLoggedForm.Visible = false;
                //重定向
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=admin_login.aspx"; //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
            else
            {
                //已登录
                if (Request.QueryString["news_id"] != null)
                {
                    //新闻id不为空
                    News deleteNews = new News();
                    deleteNews.Article_id = new Guid(Request.QueryString["news_id"]);
                    if ( newsBLL.DeleteNewsByID(deleteNews) )
                    {
                        lblDeleteStatus.Text = "删除成功，3秒后转向新闻管理首页";
                        HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                        RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                        RedirectMeta.Content = "3;url=news_manage_index.aspx"; //时间为三秒，跳转到首页
                        this.Page.Header.Controls.Add(RedirectMeta);
                    }
                    else
                    {
                        lblDeleteStatus.Text = "删除失败";
                    }
                }
                else
                {
                    //新闻id为空
                    lblDeleteStatus.Text = "新闻不存在";
                }
            }
        }
    }
}