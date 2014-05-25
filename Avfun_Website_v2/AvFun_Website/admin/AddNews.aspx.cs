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
                lblLoginStatus.Text = "您未登录或已经登录过期，请重新登录";
                lblLoginStatus.Visible = true;
                loginForm.Visible = false;
            }
            else
            {
                //已经登录
                if (!Page.IsPostBack)
                {
                    //未提交
                    //这里分两个功能：①、修改。②、添加
                    // QueryString什么都没有，就是增加，反之，参数为news_id的时候，就是修改
                    if (Request.QueryString["news_id"] != null)
                    {
                        //修改文章
                        News destNews = new News();
                        destNews.Article_id = new Guid(Request.QueryString["news_id"]);
                        News entireNews = NewsOpr.GetNewsByID(destNews);
                        if (entireNews != null)
                        {
                            //找到了
                            txtNewsContent.Text = entireNews.Article_content;
                            txtNewsTitle.Text = entireNews.Article_title;
                            imgHeadImage.ImageUrl = entireNews.News_image;
                            Boolean isOnIndex = entireNews.News_isOnIndex;
                            chkboxIsOnIndex.Checked = isOnIndex;
                        }
                        else
                        {
                            //没找到，给出提示信息
                            lblLoginStatus.Text = "文章不存在";
                            lblLoginStatus.Visible = true;
                            loginForm.Visible = false;
                        }

                    }
                }
                else
                {
                    ///提交回来了
                    if (Request.QueryString["news_id"] == null)
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
                            //这句不加清除不掉
                            newsHeadImageCookie.Path = "/admin";
                            newsHeadImageCookie.Expires = DateTime.Now.AddDays(-1d);
                            Response.Cookies.Add(newsHeadImageCookie);
                        }
                        else
                        {
                            newsHeadImage = "/news_image/default.jpg";
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
                        Guid news_id = new Guid(Request.QueryString["news_id"].ToString());
                        News destNews = new News();
                        destNews.Article_id = news_id;
                        News updateNews = NewsOpr.GetNewsByID(destNews);
                        if ( updateNews != null )
                        {
                            String news_title = Request.Form[txtNewsTitle.ID];
                            String news_content = Request.Form[txtNewsContent.ID];
                            String news_head = imgHeadImage.ImageUrl;
                            //修改了题头图片！
                            if (Request.Cookies["newsHeadImage"] != null)
                            {
                                //如果填了题头图片，分配图片地址
                                news_head = Request.Cookies["newsHeadImage"].Value.Replace("%2F","/");
                                //释放Cookies
                                HttpCookie newsHeadImageCookie = new HttpCookie("newsHeadImage");
                                newsHeadImageCookie.Expires = DateTime.Now.AddDays(-1d);
                                //这句不加清不掉
                                newsHeadImageCookie.Path = "/admin";
                                Response.Cookies.Add(newsHeadImageCookie);                               
                            }
                            Boolean isOnIndex = chkboxIsOnIndex.Checked;

                            //开始更新
                            updateNews.Article_title = news_title;
                            updateNews.Article_content = news_content;
                            updateNews.News_image = news_head;
                            updateNews.News_isOnIndex = isOnIndex;

                            if ( NewsOpr.UpdateNewsInfo(updateNews) )
                            {
                                lblLoginStatus.Text= "修改成功，若更改题头图片，请重新进入本页方能查看修改效果";
                                lblLoginStatus.Visible = true;
                            }
                            else
                            {
                                lblLoginStatus.Text = "修改失败";
                                lblLoginStatus.Visible = true;
                            }
                        }
                        else
                        {
                            lblLoginStatus.Text = "您要修改的新闻不存在";
                            lblLoginStatus.Visible = true;
                            loginForm.Visible = false;
                        }
                    }
                }
            }
        }
    }
}