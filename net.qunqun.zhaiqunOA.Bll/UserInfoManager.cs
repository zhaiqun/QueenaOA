﻿using net.qunqun.zhaiqunOA.Dal;
using net.qunqun.zhaiqunOA.IDal;
using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using net.qunqun.zhaiqunOA.DalFactory;
using net.qunqun.zhaiqunOA.IBll;

namespace net.qunqun.zhaiqunOA.Bll
{

    public   partial class UserInfoManager : BaseBll<UserInfo>, IUserInfoBll
    {
      public override IBaseDal<UserInfo> GetDal()
      {
          return dbSession.GetUserInfoDal();
      }
      public bool Login(UserLogin userModel)
      {
          var result = GetDal().Select(u => u.UserName.Equals(userModel.UName) && u.UserPwd.Equals(userModel.UPwd) );
          if (result.Count()==1)
          {
              return true;
          }
          return false;
      }
      public bool SetRole(int userId, int[] roleIds) 
      {
          dbSession.GetUserInfoDal().SetRole(userId,roleIds);
          return dbSession.EndSession() > 0;
      }
      public  bool  SetAction(int userId, int actionId, int type)
      {
            dbSession.GetUserInfoDal().SetAction(userId,actionId,type);
          return  dbSession.EndSession()>0;
      }
        //public bool Add(UserInfo model)
        //{
        //    dal.Add(model);
        //    return DbSessionFactory.GetEFSession().EndSession() > 0;
        //}
        //public IQueryable<UserInfo> SelectByRow<Tkey>(int pageSize, int pageIndex, Expression<Func<UserInfo, bool>> where, Expression<Func<UserInfo, Tkey>> orderby, out int recordCount)
        //{
        //    return dal.SelectByRow<Tkey>(pageSize, pageIndex, where, orderby, out recordCount);
        //}
    }
}
