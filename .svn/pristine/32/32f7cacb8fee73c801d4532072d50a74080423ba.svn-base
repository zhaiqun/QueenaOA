using net.qunqun.zhaiqunOA.IDal;
using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.Dal
{
  public  class RoleInfoService : BaseService<RoleInfo>,IroleInfoDal
    {
      public void SetAction(int  roleId,int[] ids)
      {
          //var roleInfo = context.Set<RoleInfo>().Where(c => c.RoleId == roleId);
             var   roleInfo = Select(roleId);
             roleInfo.ActionInfo.Clear();
             for (int i = 0; i < ids.Length; i++)
             {
                 roleInfo.ActionInfo.Add(context.Set<ActionInfo>().Find(ids[i]));
             }

      }
    }
}
