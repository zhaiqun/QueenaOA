using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.IDal
{
  public  interface IroleInfoDal : IBaseDal<RoleInfo>
    {
      void SetAction(int roleId, int[] ids);
    }
}
