using System;
namespace Avfun_BLL
{
    public interface INewsBLL
    {
        bool CreateNews(Avfun_UI.News news, Avfun_UI.Admin author);
        bool DeleteNewsByID(Avfun_UI.News news);
        Avfun_UI.News GetNewsByID(Avfun_UI.News news);
        bool isLegalNews(Avfun_UI.News news);
        bool UpdateNewsInfo(Avfun_UI.News news);
    }
}
