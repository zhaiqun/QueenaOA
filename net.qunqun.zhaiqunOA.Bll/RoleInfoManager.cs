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
    class RoleInfoManager : BaseBll<RoleInfo>, IRoleInfoBLL
    {
        public override IBaseDal<RoleInfo> GetDal()
        {
            return dbSession.GetRoleInfoDal();
        }
        public bool SetAction(int userId, int[] roleIds)
        {

            dbSession.GetRoleInfoDal().SetAction(userId, roleIds);
            return dbSession.EndSession() > 0;
        }
    }
}
