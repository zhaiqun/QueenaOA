using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net.qunqun.zhaiqunOA.IDal;
namespace net.qunqun.zhaiqunOA.Dal
{
  public partial class UserInfoService:BaseService<UserInfo>,IUserInfoDal
    {
      public void SetRole(int userId, int[] roleIds)
      {
          var userInfo = Select(userId);
          userInfo.RoleInfo.Clear();
          foreach (var roleId in roleIds)
          {
              userInfo.RoleInfo.Add(  context.Set<RoleInfo>().Find(roleId));
          }
       
      }
        public void SetAction(int userId, int actionId, int type)
        {
            var userInfo = Select(userId);
            var  result=userInfo.UserAction.Where(u => u.ActionId == actionId);
     
            if (result.Count()>0)
            {       
                var item = result.First();
                if (type==0)
                {
                    //删除现有权限
                    
                    userInfo.UserAction.Remove(item);
                }
                else
                {
                    item.HasPermission = type == 1 ? true : false;
                }
            }
            else
            {
                if (type>0)
                {
                    var item = new UserAction();
                    item.UserId = userId;
                    item.ActionId = actionId;
                    item.HasPermission = type == 1 ? true : false;
                    userInfo.UserAction.Add(item);
                }
            }
        }
    }
}
