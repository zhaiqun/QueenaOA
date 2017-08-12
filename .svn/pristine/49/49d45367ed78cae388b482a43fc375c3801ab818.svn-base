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
   public  partial class   DepartInfoManager:BaseBll<DepartInfo>,IDepartInfoBll
    {
        public override IBaseDal<DepartInfo> GetDal()
        {
            return dbSession.GetDepartInfoDal();
        }
    }
}
