using net.qunqun.zhaiqunOA.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.DalFactory
{
    public interface IDbSession
    {
          UserInfoService GetUserInfoDal();
          DepartInfoService GetDepartInfoDal();
          RoleInfoService GetRoleInfoDal();
          ActionInfoService GetActionInfoDal();
          int EndSession();
    }
}
