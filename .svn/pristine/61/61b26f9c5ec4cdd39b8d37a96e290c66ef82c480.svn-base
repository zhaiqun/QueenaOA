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
    public class RoleInfoController : Controller
    {
        //
        // GET: /RoleInfo/
        public IRoleInfoBLL roleInfoBll { set; get; }
        public IActionInfoBll actionInfoBll { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPageList(int page, int rows)
        {
            int rowCount;
            var result = roleInfoBll.SelectByRow(rows, page, c => c.IsDelete == false, c => c.RoleId, out rowCount)
                .Select(u => new { u.RoleId, u.RoleName });
            return Json(new { total = rowCount, rows = result });
        }
        public ActionResult Add(RoleInfo model)
        {
            string result = "0";
            model.IsDelete = false;
            model.SubBy = 1;
            model.SubTime = DateTime.Now;
            bool b = roleInfoBll.Add(model);
            if (b)
            {
                result = "1";
            }
            return Content(result);
        }

        public ActionResult Edit(int id)
        {
            RoleInfo model = roleInfoBll.Select(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RoleInfo model)
        {
            string result = "0";
            model.SubBy = 1;
            model.SubTime = DateTime.Now;
            model.IsDelete = false;
            bool b = roleInfoBll.Edit(model);
            if (b)
            {
                result = "1";
            }
            return Content(result);
        }

        public ActionResult Remove(int id)
        {
            string result = "0";
            bool b = roleInfoBll.Delete(id);
            if (b)
            {
                result = "1";
            }
            return Content(result);
        }
        public ActionResult SetAction(int id)
        {
            RoleSetActionModel ra = new RoleSetActionModel();
            ra.RoleModel = roleInfoBll.Select(id);
            ra.ActionModels = actionInfoBll.Select(u => u.IsDelete == false).ToList();

            return View(ra);
        }
        [HttpPost]
        public ActionResult SetAction(int roleId, string ids)
        {
            string result = "0";
            List<int> list = new List<int>();
            foreach (var id in ids.Split(','))
            {
                list.Add(int.Parse(id));
            }
           bool b= roleInfoBll.SetAction(roleId, list.ToArray());
           if (b)
           {
               result = "1";
           }
            return Content(result);
        }
    }

}

