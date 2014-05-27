using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avfun_UI
{
    public class Review : GeneralArticle
    {
        private Guid review_news;

        public Guid Review_news
        {
            get { return review_news; }
            set { review_news = value; }
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

        public Review(Review review)
        {
            this.a_id = review.A_id;
            this.article_id = review.Article_id;
            this.article_title = review.Article_title;
            this.article_content = review.Article_content;
            this.article_author = review.Article_author;
            this.article_publish_date = review.Article_publish_date;
            this.article_isDeleted = review.Article_isDeleted;

            this.review_news = review.Review_news;
        }

        public Review(String content, Guid author, DateTime publish_date, Guid review_news)
        {
            this.article_content = content;
            this.article_author = author;
            this.article_publish_date = publish_date;
            this.review_news = review_news;
        }
    }
}