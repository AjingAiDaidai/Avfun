using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Avfun_UI;
namespace Avfun_DAL
{
    public class DALFactory:IDALFactory
    {
            //获取程序集名称
            private readonly static String assemblyName = Assembly.GetExecutingAssembly().FullName;

            //获取当前命名空间
            private readonly static String namespaceName = "Avfun_DAL";
            //指定当前数据库类型
            private readonly static String nowDatabaseName = ReadAppConfig.GetAppConfig("CurrentDatabase");
            /// <summary>
            /// 根据类名返回类的对应实例
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="className">类名称</param>
            /// <returns></returns>
            public static T CreateInstance<T>(string className)
            {
                String fullName = namespaceName + "." + nowDatabaseName + className;
                Object result = Assembly.Load(assemblyName).CreateInstance(fullName);
                return (T)result;
            }
    }
}
