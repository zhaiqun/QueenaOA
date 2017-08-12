using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace net.qunqun.zhaiqunOA.IBll
{
 public   interface IBaseBll<T>
    {

     IQueryable<T> Select(Expression<Func<T, bool>> where);
        bool Add(T model);
        bool Edit(T model);
        bool Delete(T model);
        bool Delete(int id);
        bool Delete(int[] id);
        T Select(int id);
        IQueryable<T> SelectByRow<Tkey>(int pageSize, int pageIndex, Expression<Func<T, bool>> where, Expression<Func<T, Tkey>> orderby, out  int recordeCount);
    }
}
