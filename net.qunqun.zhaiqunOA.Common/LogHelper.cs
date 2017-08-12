using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.Common
{
   public    static class LogHelper
    {
       private static object obj;
       private static Queue<string> que;
          static LogHelper()
       {
           que = new Queue<string>();
           Thread th = new Thread(new ThreadStart(() =>
           {
               if (que.Count>0)
               {
                   string msg=que.Dequeue();
                   if (msg.Length>0)
                   {
                        string[] strs = { "========", msg, "===============" };
                        File.AppendAllLines("d://log1.txt", strs); 
                   }
               }
               else
               {
                   Thread.Sleep(1000);
               }
              
           }));
           th.IsBackground = true;
           th.Start();
       }
       //public static void WriteLog(string  errorStr)
       //{
       //    lock (errorStr)//加锁为了线程安全
       //    {
       //        string[] strs = { "========", errorStr, "===============" };
       //        File.WriteAllLines("d://log.txt", strs); 
       //    }
       //}
       public static void MessageEnqueue(string msg)
       { 
         
                que.Enqueue(msg);
        
       }
    }
}
