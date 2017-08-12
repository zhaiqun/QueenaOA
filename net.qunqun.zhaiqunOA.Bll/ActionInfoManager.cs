using net.qunqun.zhaiqunOA.IBll;
using net.qunqun.zhaiqunOA.IDal;
using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.Bll
{
  public  class ActionInfoManager:BaseBll<ActionInfo>,IActionInfoBll
    {
      public override IBaseDal<ActionInfo> GetDal()
      {
          return dbSession.GetActionInfoDal();
      }
    }
}
