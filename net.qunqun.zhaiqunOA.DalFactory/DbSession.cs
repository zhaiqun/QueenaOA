﻿using net.qunqun.zhaiqunOA.Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.DalFactory
{
    public class DbSession :  BaseSession,IDbSession
    {
        public  override int EndSession()
        {
            DbContext context = ContextFactory.GetContext();
            return  context.SaveChanges();
        }
    }
}
