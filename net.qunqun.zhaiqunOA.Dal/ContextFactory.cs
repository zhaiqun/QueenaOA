﻿using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.Dal
{
  public   class ContextFactory
    {
         public  static DbContext GetContext()
         {
             DbContext context = CallContext.GetData("context")  as DbContext;
             if (context==null)
             {
                 context = new OAcontext();
                 CallContext.SetData("context", context);
             }
             return context;
         }
    }
}
