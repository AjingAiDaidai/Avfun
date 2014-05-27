using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace Avfun_BLL
{
    /// <summary>
    /// BLL层的抽象工厂类的具体实现
    /// </summary>
    public class BLLFactory:IBLLFactory
    {
        //获取程序集名称
        private readonly static String assemblyName = Assembly.GetExecutingAssembly().FullName;
        
        //获取当前命名空间
        private static String namespaceName = "Avfun_BLL";
        /// <summary>
        /// 根据类名返回类的对应实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="className">类名称</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string className)
        {
            String fullName = namespaceName + "." + className;
            Object result = Assembly.Load(assemblyName).CreateInstance(fullName);
            return (T)result;
        }
    }
}