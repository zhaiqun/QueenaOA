using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.DalFactory
{
  public  class DbSessionFactory
    {
      public  static IDbSession GetEFSession()
      {
          return  new DbSession();
      } 
    }
}
