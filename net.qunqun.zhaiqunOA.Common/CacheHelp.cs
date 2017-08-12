using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.Common
{
    public class CacheHelp
    {
        public static void Insert(string key, object value)
        {
            System.Web.Caching.Cache cache = System.Web.HttpRuntime.Cache;
            cache[key] = value;
        }
        public static object Get(string key)
        {
            System.Web.Caching.Cache cache = System.Web.HttpRuntime.Cache;
            return cache[key];
        }
    }
}
