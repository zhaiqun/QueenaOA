﻿using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.IBll
{
   public  interface IRoleInfoBLL:IBaseBll<RoleInfo>
    {
       bool SetAction(int roleId, int[] ids);
    }
}
