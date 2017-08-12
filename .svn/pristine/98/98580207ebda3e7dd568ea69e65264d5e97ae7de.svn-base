using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.IDal
{
   public    interface IBaseDal<T>  where T:class
    {
       IQueryable<T> Select(Expression<Func<T, bool>> where);
       void Add(T model);
        void Edit(T model);
       void Delete(T model);
       void Delete(int id);
       void Delete(int[] id);
       IQueryable<T>  SelectByRow<Tkey>(int pageSize,int pageIndex,Expression<Func<T,bool>> where, Expression<Func<T,Tkey>> orderby,  out  int recordeCount);
       T Select(int  id);
   
    }
}
