using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using AvFun_Website.Avfun_BLL;
using AvFun_Website.AvFun_UI;
namespace AvFun_Website.admin
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Admin loggedAdmin = AdminOpr.isLogged(Request);
            if (loggedAdmin == null)
            {
                //未登录
                lblLoginStatus.Text = "您未登录或已经登录过期，请重新登录，3秒后转回管理员登录页。";
                lblLoginStatus.Visible = true;
                loginForm.Visible = false;
                //重定向
                HtmlMeta RedirectMeta = new HtmlMeta(); //重定向用Meta标签
                RedirectMeta.HttpEquiv = "refresh"; //指定行为为跳转
                RedirectMeta.Content = "3;url=admin_login.aspx"; //时间为三秒，跳转到首页
                this.Page.Header.Controls.Add(RedirectMeta);
            }
            else
            {
                //已经登录
                if (!Page.IsPostBack)
                {
                    //未提交
                    //这里分两个功能：①、修改。②、添加
                }
                else
                {
                    if (Request.QueryString["action"] == null)
                    {
                        //增加用
                        String newsTitle = Request.Form[txtNewsTitle.ID];
                        String newsContent = Request.Form[txtNewsContent.ID];
                        String newsHeadImage = null;
                        if (Request.Cookies["newsHeadImage"] != null)
                        {
                            //如果填了题头图片，分配图片地址
                            newsHeadImage = Request.Cookies["newsHeadImage"].Value.Replace("%2F","/");
                            //释放Cookies
                            HttpCookie newsHeadImageCookie = new HttpCookie("newsHeadImage");
                            newsHeadImageCookie.Expires = DateTime.Now.AddDays(-1D);
                            Response.Cookies.Add(newsHeadImageCookie);
                        }
                        else
                        {
                            newsHeadImage = "news_image/default.jpg";
                        }
                        DateTime news_publish_date = DateTime.Now;
                        Boolean news_isDeleted = false;
                        Boolean news_isOnIndex = chkboxIsOnIndex.Checked;
                        int news_click_count = 0;
                        Guid news_author = loggedAdmin.User_id;
                        Guid news_id = System.Guid.NewGuid();
                        News newNews = new News();

                        newNews.Article_id = news_id;
                        newNews.Article_content = newsContent;
                        newNews.Article_title = newsTitle;
                        newNews.Article_author = news_author;
                        newNews.Article_publish_date = news_publish_date;
                        newNews.Article_isDeleted = news_isDeleted;
                        newNews.News_isOnIndex = news_isOnIndex;
                        //去空格否则bug
                        newNews.News_image = newsHeadImage.Trim();
                        newNews.News_click_count = news_click_count;

                        if (NewsOpr.CreateNews(newNews, loggedAdmin))
                        {
                            //创建成功
                            loginForm.Visible = true;
                            lblLoginStatus.Text = "添加新闻成功";
                            lblLoginStatus.Visible = true;
                        }
                        else
                        {
                            lblLoginStatus.Text = "添加新闻失败，请检查各项是否已经填写";
                            lblLoginStatus.Visible = true;
                            loginForm.Visible = true;
                        }
                    }
                    else
                    {
                        //修改用
                    }
                }
            }
        }
    }
}