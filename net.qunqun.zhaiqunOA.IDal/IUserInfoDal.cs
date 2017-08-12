using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.IDal
{
   public  partial interface IUserInfoDal:IBaseDal<UserInfo>
    {
       void SetRole(int userId, int[] roleIds);
       void SetAction(int userId, int actionId, int type);
    }
}
