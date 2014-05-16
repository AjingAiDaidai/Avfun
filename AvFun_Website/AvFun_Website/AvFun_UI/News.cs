using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvFun_Website.AvFun_UI
{
    public class News : GeneralArticle
    {

        private Boolean news_isOnIndex;

        public Boolean News_isOnIndex
        {
            get { return news_isOnIndex; }
            set { news_isOnIndex = value; }
        }
        private String news_image; // 长度256

        public String News_image
        {
            get { return news_image; }
            set { news_image = value; }
        }
        private int news_click_count;

        public int News_click_count
        {
            get { return news_click_count; }
            set { news_click_count = value; }
        }

        public override int A_id
        {
            get { return this.a_id; }
        }

        public override Guid Article_id
        {
            get
            {
                return this.article_id;
            }
            set
            {
                this.article_id = value;
            }
        }

        public override String Article_title
        {
            get
            {
                return this.article_title;
            }
            set
            {
                this.article_title = value;
            }
        }

        public override string Article_content
        {
            get
            {
                return this.article_content;
            }
            set
            {
                this.article_content = value;
            }
        }

        public override Guid Article_author
        {
            get
            {
                return this.article_author;
            }
            set
            {
                this.article_author = value;
            }
        }

        public override DateTime Article_publish_date
        {
            get
            {
                return this.article_publish_date;
            }
            set
            {
                this.article_publish_date = value;
            }
        }

        public override bool Article_isDeleted
        {
            get
            {
                return this.article_isDeleted;
            }
            set
            {
                this.article_isDeleted = value;
            }
        }

        public News(News news)
        {
            this.a_id = news.A_id;
            this.article_id = news.Article_id;
            this.article_author = news.Article_author;
            this.article_title = news.Article_title;
            this.article_content = news.Article_content;
            this.article_publish_date = news.Article_publish_date;
            this.article_isDeleted = news.Article_isDeleted;

            this.news_image = news.News_image;
            this.news_isOnIndex = news.News_isOnIndex;
        }
        public News(Guid author, String title, String content, DateTime publish_date, String image, Boolean isOnIndex)
        {
            this.article_author = author;
            this.article_title = title;
            this.article_content = content;
            this.article_publish_date = publish_date;
            this.news_image = image;
            this.news_isOnIndex = isOnIndex;
        }
    }
}