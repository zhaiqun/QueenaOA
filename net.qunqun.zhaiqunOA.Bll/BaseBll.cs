﻿using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using net.qunqun.zhaiqunOA.IDal;
using net.qunqun.zhaiqunOA.DalFactory;
namespace net.qunqun.zhaiqunOA.Bll
{
   public  abstract class BaseBll<T>  where T:class
    {
       protected IDbSession dbSession; 
       public abstract IBaseDal<T> GetDal();
       public BaseBll()
       {
           dbSession = DbSessionFactory.GetEFSession();
           
       }
       public IQueryable<T> Select(Expression<Func<T, bool>> where)
       {
           return GetDal().Select(where);
       }
       public T Select(int id)
       {
           return GetDal().Select(id);
       }
        public bool Add(T  model)
        {
            GetDal().Add(model);
          return  dbSession.EndSession()>0;
           
        }
        public bool Edit(T model)
        {
            GetDal().Edit(model) ;
            return dbSession.EndSession() > 0;
        }
        public  bool Delete(T model)
        {
            GetDal().Delete(model) ;
            return dbSession.EndSession() > 0;
        }
        public bool Delete(int id)
        {
            GetDal().Delete(id);
            return dbSession.EndSession() > 0;
        }
        public bool Delete(int[] ids)
        {
            GetDal().Delete(ids);
            return dbSession.EndSession() > 0;
        }
        public IQueryable<T> SelectByRow<Tkey>(int pageSize, int pageIndex, Expression<Func<T, bool>> where, Expression<Func<T, Tkey>> orderby, out int recordCount)
        {
            return GetDal().SelectByRow<Tkey>(pageSize, pageIndex, where, orderby, out recordCount);
        }
    }
}
