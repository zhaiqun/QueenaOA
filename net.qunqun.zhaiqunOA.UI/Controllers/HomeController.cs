using net.qunqun.zhaiqunOA.IBll;
using net.qunqun.zhaiqunOA.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace net.qunqun.zhaiqunOA.UI.Controllers
{
    public class HomeController :Controller
    {


        public IActionInfoBll actionInfoBll { set; get; }
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用 ASP.NET MVC!";
            var result = actionInfoBll.Select(u => (u.IsMenu == true) && (u.IsDelete == false));

            return View(result);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
