﻿using net.qunqun.zhaiqunOA.Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.DalFactory
{
    public abstract class BaseSession
    {
        public UserInfoService GetUserInfoDal()
        {
            return new UserInfoService();
        }
        public DepartInfoService GetDepartInfoDal()
        {
            return new DepartInfoService();
        }

        public RoleInfoService GetRoleInfoDal()
        {
            return new RoleInfoService();
        }
        public ActionInfoService GetActionInfoDal()
        {
            return new ActionInfoService();
        }
        public abstract int EndSession();

    }
}
