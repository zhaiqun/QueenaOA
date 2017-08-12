using Memcached.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] servers = { "192.168.1.102:11211" };

            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(servers);
            pool.Initialize();

            MemcachedClient client = new MemcachedClient();
            client.EnableCompression = false;
            client.Set("zhaiqun","12345");
            Console.WriteLine(client.Get("zhaiqun"));
            Console.ReadKey();
        }
    }
}
