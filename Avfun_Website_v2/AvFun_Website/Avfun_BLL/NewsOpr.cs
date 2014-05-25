using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AvFun_Website.AvFun_UI;
using AvFun_Website.Avfun_DAL;
namespace AvFun_Website.Avfun_BLL
{
    public class NewsOpr
    {
        /// <summary>
        /// 更新新闻信息，成功返回true，否则返回false
        /// </summary>
        /// <param name="news">要更新的新闻类，必须含有新闻的完整信息。</param>
        /// <returns>成功返回true，失败返回false</returns>
        public static Boolean UpdateNewsInfo(News news)
        {
            Boolean result = false;
            if (!isLegalNews(news))
            {
                result = false;
            }
            else
            {
                NewsData newsData = NewsData.GetInstance();
                result = newsData.UpdateNewsInfo(news);
            }
            return result;
        }
        /// <summary>
        /// 根据ID来获得完整新闻对应的的News类，其中参数的article_id必填
        /// 获取到了返回News对象，否则返回Null
        /// </summary>
        /// <param name="news">要获取的News类</param>
        /// <returns>包含完整信息的news类，若找不到或者失败，返回null</returns>
        public static News GetNewsByID(News news)
        {
            News ResultNews = null;
            /* 数据合法性检查 */
            if (news.Article_id == null
                )
            {
                ResultNews = null;
            }
            else
            {
                NewsData newsData = NewsData.GetInstance();
                ResultNews = newsData.GetNewsByID(news);
            }
            return ResultNews;
        }
        /// <summary>
        /// 检查新闻类的数据规范
        /// </summary>
        /// <param name="news">要检查的新闻类</param>
        /// <returns>合格返回true，否则返回false</returns>
        public static Boolean isLegalNews(News news)
        {
            Boolean result = true;
            //文章标题检查
            if (news.Article_title.Length > 128
                || news.Article_title.Length < 1
                || news.Article_title.Equals("")
                || news.Article_title == null)
            {
                result = false;
            }
            if (news.Article_content.Length < 1
                || news.Article_content.Equals("")
                || news.Article_content == null
               )
            {
                result = false;
            }
            if (news.Article_publish_date == null)
            {
                result = false;
            }
            if (news.Article_author == null)
            {
                result = false;
            }
            if (news.News_image == null
                || news.News_image.Equals("")
                || news.News_image.Length > 256
                || news.News_image.Length < 1)
            {
                result = false;
            }
            if (news.News_click_count < 0)
            {
                result = false;
            }
            return result;  
        }
        /// <summary>
        /// 发布新闻
        /// </summary>
        /// <param name="news">要发布的新闻类</param>
        /// <param name="author">作者</param>
        /// <returns>成功返回true，失败返回false</returns>
        public static Boolean CreateNews(News news, Admin author)
        {
            Boolean result = true;
            if ( !isLegalNews(news) || !AdminOpr.isLegalNewAdmin(author) )
            {
                //数据合法性检查未通过
                result = false;
            }
            else
            {
                news.Article_author = author.User_id;
                NewsData newsData  = NewsData.GetInstance();
                result = newsData.CreateNews(news);
            }
            return result;
        }
        /// <summary>
        /// 根据给定新闻id删除新闻（UPDATE isDeleted = true），成功返回true，失败返回false
        /// </summary>
        /// <param name="news">要删除的新闻</param>
        /// <returns>成功返回true，失败返回false</returns>
        public static Boolean DeleteNewsByID(News news)
        {
            Boolean result = false;
            //数据合法性检查
            if (news.Article_id != null)
            {
                NewsData newsData = NewsData.GetInstance();
                result = newsData.DeleteNewsByID(news);
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}