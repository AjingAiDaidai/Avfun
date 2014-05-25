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
        public  Boolean UpdateNewsInfo(News news)
        {
        }
        /// <summary>
        /// 根据ID来获得完整新闻对应的的News类，其中参数的article_id必填
        /// 获取到了返回News对象，否则返回Null
        /// </summary>
        /// <param name="news">要获取的News类</param>
        /// <returns>包含完整信息的news类，若找不到或者失败，返回null</returns>
        public  News GetNewsByID(News news)
        {
        }
        /// <summary>
        /// 检查新闻类的数据规范
        /// </summary>
        /// <param name="news">要检查的新闻类</param>
        /// <returns>合格返回true，否则返回false</returns>
        public  Boolean isLegalNews(News news)
        {
        }
        /// <summary>
        /// 发布新闻
        /// </summary>
        /// <param name="news">要发布的新闻类</param>
        /// <param name="author">作者</param>
        /// <returns>成功返回true，失败返回false</returns>
        public  Boolean CreateNews(News news, Admin author)
        {
        }
        /// <summary>
        /// 根据给定新闻id删除新闻（UPDATE isDeleted = true），成功返回true，失败返回false
        /// </summary>
        /// <param name="news">要删除的新闻</param>
        /// <returns>成功返回true，失败返回false</returns>
        public  Boolean DeleteNewsByID(News news)
        {
        }
        /// <summary>
        /// 获取NewsOpr类的一个实例
        /// </summary>
        /// <returns></returns>
        public static NewsOpr GetNewInstance()
        {
        }
    }
}