﻿using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.Dal
{
    public class BaseService<T> where T : class
    {
        protected  DbContext context = ContextFactory.GetContext();
        public IQueryable<T> Select(Expression<Func<T, bool>> where)
        {
            return context.Set<T>().Where(where);
        }
        public void Add(T model)
        {

            context.Set<T>().Add(model);
            // return context.SaveChanges();
        }
        public void Edit(T model)
        {
            context.Entry<T>(model).State = EntityState.Modified;
            //return context.SaveChanges();
        }
        public void Delete(T model)
        {
            context.Entry<T>(model).State = EntityState.Deleted;
            // return context.SaveChanges();
        }
        public void Delete(int  id)
        {
            var obj = Select(id);
            context.Entry(obj).Property("IsDelete").CurrentValue = true;
            context.Entry(obj).Property("IsDelete").IsModified = true;
        }
        public void Delete(int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                Delete(ids[i]);
            }
        }
        public IQueryable<T> SelectByRow<Tkey>(int pageSize, int pageIndex, Expression<Func<T, bool>> where, Expression<Func<T, Tkey>> orderby, out int recordCount)
        {
            recordCount = context.Set<T>().Where(where).Count();
            return context.Set<T>().Where(where).OrderBy(orderby).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        public T Select(int id)
        {
            return context.Set<T>().Find(id);
        }
    }
}
