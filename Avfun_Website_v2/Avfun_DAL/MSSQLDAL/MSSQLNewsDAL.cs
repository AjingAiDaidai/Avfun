using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Avfun_UI;
namespace Avfun_DAL
{
    public class MSSQLNewsDAL : INewsDAL
    {
        public News ConvertNEWSToNews(NEWS news)
        {
            News ResultNews = new News();
            ResultNews.Article_title = news.news_title;
            ResultNews.Article_id = news.news_id; 
            ResultNews.Article_content = news.news_content;
            ResultNews.Article_isDeleted = news.news_isDeleted;
            ResultNews.News_isOnIndex = news.news_isOnIndex;
            ResultNews.Article_publish_date = news.news_publish_date;
            ResultNews.Article_timestamp = news.news_timestamp;
            ResultNews.Article_author = news.news_author;
            ResultNews.News_click_count = news.news_click_count;
            ResultNews.News_image = news.news_image;
            return ResultNews;
        }
        public NEWS ConvertNewsToNEWS(News news)
        {
            NEWS ResultNEWS = new NEWS();
            ResultNEWS.news_title = news.Article_title;
            ResultNEWS.news_id = news.Article_id;
            ResultNEWS.news_content = news.Article_content;
            ResultNEWS.news_isDeleted = news.Article_isDeleted;
            ResultNEWS.news_isOnIndex = news.News_isOnIndex;
            ResultNEWS.news_publish_date = news.Article_publish_date;
            ResultNEWS.news_timestamp = news.Article_timestamp;
            ResultNEWS.news_author = news.Article_author;
            ResultNEWS.news_click_count = news.News_click_count;
            ResultNEWS.news_image = news.News_image;
            return ResultNEWS;
        }
        /// <summary>
        /// 根据参数的article_id返回包含完整信息的News类，失败返回null
        /// </summary>
        /// <param name="news">包含了news的ID的News对象</param>
        /// <returns>成功返回包含完整信息的News对象，否则返回Null</returns>
        public News GetNewsByID(News news)
        {
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            News result = null;
            try
            {
                NEWS ResultNEWS = (from destNews in DataEntity.NEWS
                         where
                         destNews.news_id == news.Article_id
                                       select destNews).Single();
                result = ConvertNEWSToNews(ResultNEWS);
            }
            catch
            {
                result = null;
            }
            return result;
        }
        /// <summary>
        /// 更新新闻信息，成功返回true，失败返回false
        /// </summary>
        /// <param name="news">要更新的news类</param>
        /// <returns>成功返回true，失败返回false</returns>
        public Boolean UpdateNewsInfo(News news)
        {
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            Boolean result = false;
            try
            {
                NEWS ResultNEWS = (from destNews in DataEntity.NEWS
                                  where destNews.news_id == news.Article_id
                                  && destNews.news_timestamp == news.Article_timestamp
                                       select destNews ).Single();
                
                ResultNEWS.news_title = news.Article_title;
                ResultNEWS.news_id = news.Article_id;
                ResultNEWS.news_content = news.Article_content;
                ResultNEWS.news_isDeleted = news.Article_isDeleted;
                ResultNEWS.news_isOnIndex = news.News_isOnIndex;
                ResultNEWS.news_publish_date = news.Article_publish_date;
                ResultNEWS.news_timestamp = news.Article_timestamp;
                ResultNEWS.news_author = news.Article_author;
                ResultNEWS.news_click_count = news.News_click_count;
                ResultNEWS.news_image = news.News_image;

                DataEntity.SaveChanges();

                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 插入新闻，成功返回true，失败返回false
        /// </summary>
        /// <param name="news">要插入的新闻类</param>
        /// <returns>成功true，失败false</returns>
        public Boolean CreateNews(News news)
        {
            Boolean result = true;
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            try
            {
                NEWS newNEWS = ConvertNewsToNEWS(news);
                DataEntity.NEWS.AddObject(newNEWS);
                DataEntity.SaveChanges();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 根据给定的news_id将NEWS表中的对应新闻列isDeleted设为true
        /// </summary>
        /// <param name="news">填写了news_id的news类</param>
        /// <returns>成功返回true，失败返回false</returns>
        public Boolean DeleteNewsByID(News news)
        {
            avfunEntities DataEntity = DataEntityManager.GetDataEntity();
            Boolean result = false;
            try
            {
                NEWS destNews = (from d_news in DataEntity.NEWS
                                 where d_news.news_id == news.Article_id
                                 select d_news).Single();
                destNews.news_isDeleted = true;
                DataEntity.SaveChanges();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}