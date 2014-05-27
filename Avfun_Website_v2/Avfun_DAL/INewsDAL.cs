using System;
namespace Avfun_DAL
{
    public interface INewsDAL
    {
        Avfun_UI.News ConvertNEWSToNews(NEWS news);
        NEWS ConvertNewsToNEWS(Avfun_UI.News news);
        bool CreateNews(Avfun_UI.News news);
        bool DeleteNewsByID(Avfun_UI.News news);
        Avfun_UI.News GetNewsByID(Avfun_UI.News news);
        bool UpdateNewsInfo(Avfun_UI.News news);
    }
}
