using net.qunqun.zhaiqunOA.Bll;
using net.qunqun.zhaiqunOA.BllFactory;
using net.qunqun.zhaiqunOA.IBll;
using net.qunqun.zhaiqunOA.Model;
using net.qunqun.zhaiqunOA.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace net.qunqun.zhaiqunOA.UI.Controllers
{
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/
        IUserInfoBll bll = BllFactoryClass.GetUserInfoBll();
       
        public ActionResult Index()
        {
            int recordCount;
            int pageSize = 7;
            int pageIndex = 1;
            IQueryable<UserInfo> model = bll.SelectByRow<int>(pageSize, pageIndex, c => true, c => c.UserId, out recordCount);
            ViewData.Model = model;
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Add(UserInfo model)
        {
            model.SubBy = 1;
            model.SubTime = DateTime.Now;
            model.IsDelete = false;
          
             bool b= bll.Add(model);
             if (b)
             {
                 return Redirect(Url.Action("Index"));
             }
             else
             {
                 return Content("增加数据失败");
             }
        }
    }
}
