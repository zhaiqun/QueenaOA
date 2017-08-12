using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.IBll
{
   public  partial interface IUserInfoBll:IBaseBll<UserInfo>
    {
       bool Login(UserLogin model);
       bool SetRole(int userId, int[] roleIds);
       bool SetAction(int userId, int actionId, int type);
    }
}
