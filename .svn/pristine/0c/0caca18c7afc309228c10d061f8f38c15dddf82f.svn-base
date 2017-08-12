using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.Common
{
   public static class MMhelper
    {
       private static MemcachedClient client;
        static MMhelper()
       {
           string[] serverList = System.Configuration.ConfigurationManager.AppSettings["serverList"].Split(',');
           SockIOPool pool = SockIOPool.GetInstance();
           pool.SetServers(serverList);
           pool.Initialize();
           client = new MemcachedClient();
       }
       public static void Set(string key,object value,DateTime expire)
       {
         
           client.Set(key, value, expire);
       }
       public static object Get(string key)
       {
           object  obj=client.Get(key);
           return obj;
       }
       public static void Delete(string key )
       {
           client.Delete(key);
       }
    }
}
