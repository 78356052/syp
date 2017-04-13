using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZW.Syp.IDAL;

namespace ZW.Syp.DALFactory
{
    /// <summary>
    /// 抽象工厂：解决对象创建的问题
    /// </summary>
    public class DALAbstractFactory
    {
        private static readonly string DalNameSpace = ConfigurationManager.AppSettings["DalNameSpace"];//获取命名空间
        private static readonly string DalAssembly = ConfigurationManager.AppSettings["DalAssembly"];

        public static IUserDal CreateUserDal()
        {
            string fullClassName = DalNameSpace + ".UserDal";//构建类的全名称
            return CreateInstance(fullClassName, DalAssembly) as IUserDal;
        }

        private static object CreateInstance(string fullClassName, string assemblyPath)
        {
            var assembly = Assembly.Load(assemblyPath);//加载程序集
            return assembly.CreateInstance(fullClassName);
        }
    }
}
