using net.qunqun.zhaiqunOA.Common;
using net.qunqun.zhaiqunOA.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.DalFactory
{
   public  class DalFactoryAbstract
    {
      static  string  namespaceName = System.Configuration.ConfigurationManager.AppSettings["Namespace"];
      static string assemblyName = System.Configuration.ConfigurationManager.AppSettings["Assembly"];
       public static IUserInfoDal GetUserInfoDal()
       {
           string fullName = namespaceName + ".UserInfoService";
           return CreateInstance(fullName, assemblyName)  as IUserInfoDal;
       }

       private static object CreateInstance(string fullName, string assemblyName)
       {
           object instance = CacheHelp.Get(fullName);
           if (instance==null)
           {
               var ass = Assembly.Load(assemblyName);
               instance=  ass.CreateInstance(fullName);
           }
           return instance;
       }
    }
}
