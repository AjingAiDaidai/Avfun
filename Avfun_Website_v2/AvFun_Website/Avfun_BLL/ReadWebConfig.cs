using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvFun_Website.Avfun_BLL
{
    public class ReadWebConfig
    {
        #region 读取网站信息
        /// <summary>
        /// 获取写在Web.config里面的appsetting节的内容，如果没有对应节返回null
        /// </summary>
        /// <param name="KeyName">要读取节的KeyName</param>
        /// <returns>对应节的值，没有则返回null </returns>
        public static String GetAppSettingValue(String KeyName)
        {
            //注意！这里的值是从网站根目录WebConfig读取的
            System.Configuration.Configuration rootWebConfig1 =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/web.config");
            if (rootWebConfig1.AppSettings.Settings.Count > 0)
            {
                System.Configuration.KeyValueConfigurationElement customSetting =
                 rootWebConfig1.AppSettings.Settings[KeyName];
                if (customSetting != null)
                   return customSetting.Value;
                else
                {

                    return null;
                }
            }
            else
              return null;
        }
        #endregion
    }
}