using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace net.qunqun.zhaiqunOA.UI.Models
{
    public class SetRoleViewModel
    {
        public UserInfo UserModel { get; set; }
        public List<RoleInfo> RoleModels { set; get; }
    }
}