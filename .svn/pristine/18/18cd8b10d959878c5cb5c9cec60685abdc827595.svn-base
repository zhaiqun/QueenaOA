using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.Common
{
   public class Md5Helper
    {
        public static string GetMd5(string msg)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);
            byte[] bufferMd5;
            using (MD5 md5 = MD5.Create())
            {
                 bufferMd5 = md5.ComputeHash(buffer);
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bufferMd5.Length; i++)
            {
                sb.Append(bufferMd5[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
