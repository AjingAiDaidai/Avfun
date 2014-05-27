using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Avfun_DAL
{
    class ReadAppConfig
    {
        
        public static string GetAppConfig(String strKey)
        {

            foreach (String key in System.Configuration.ConfigurationManager.AppSettings)
            {
                if (key.Equals(strKey) )
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }  
    }
}
