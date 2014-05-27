using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avfun_UI
{
    public abstract class GeneralArticle
    {
        protected int a_id;

        public abstract int A_id
        {
            get;
        }
        protected Guid article_id;

        public abstract Guid Article_id
        {
            get;
            set;
        }
        /// <summary>
        /// 长128
        /// </summary>
        protected String article_title;

        public abstract String Article_title
        {
            get;
            set;
        }
        protected String article_content;

        public abstract String Article_content
        {
            get;
            set;
        }
        /// <summary>
        /// 和GeneralUser的子类有外键关系
        /// </summary>
        protected Guid article_author;

        public abstract Guid Article_author
        {
            get;
            set;
        }
        protected DateTime article_publish_date;

        public abstract DateTime Article_publish_date
        {
            get;
            set;
        }
        protected Boolean article_isDeleted;

        public abstract Boolean Article_isDeleted
        {
            get;
            set;
        }

        protected byte[] article_timestamp;

        public byte[] Article_timestamp
        {
            get { return article_timestamp; }
            set { article_timestamp = value; }
        }
    }
}