using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avfun_DAL
{
    class OracleNewsDAL:INewsDAL
    {
        Avfun_UI.News INewsDAL.ConvertNEWSToNews(NEWS news)
        {
            throw new NotImplementedException();
        }

        NEWS INewsDAL.ConvertNewsToNEWS(Avfun_UI.News news)
        {
            throw new NotImplementedException();
        }

        bool INewsDAL.CreateNews(Avfun_UI.News news)
        {
            throw new NotImplementedException();
        }

        bool INewsDAL.DeleteNewsByID(Avfun_UI.News news)
        {
            throw new NotImplementedException();
        }

        Avfun_UI.News INewsDAL.GetNewsByID(Avfun_UI.News news)
        {
            throw new NotImplementedException();
        }

        bool INewsDAL.UpdateNewsInfo(Avfun_UI.News news)
        {
            throw new NotImplementedException();
        }
    }
}
