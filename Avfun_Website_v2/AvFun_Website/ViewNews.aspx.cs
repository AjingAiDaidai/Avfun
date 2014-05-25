using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AvFun_Website.Avfun_BLL;
using AvFun_Website.AvFun_UI;
namespace AvFun_Website
{
    public partial class ViewNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["news_id"] != null)
            {
                Guid news_id = new Guid(Request.QueryString["news_id"].ToString());
                News toFindNews = new News();
                toFindNews.Article_id =  news_id;
                News entireNews = NewsOpr.GetNewsByID(toFindNews);
                if ( entireNews != null )
                {
                    entireNews.News_click_count += 1;
                    NewsOpr.UpdateNewsInfo(entireNews);
                }
            }
        }
    }
}