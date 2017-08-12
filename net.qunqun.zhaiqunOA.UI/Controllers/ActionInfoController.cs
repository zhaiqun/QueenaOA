﻿using net.qunqun.zhaiqunOA.IBll;
using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace net.qunqun.zhaiqunOA.UI.Controllers
{
    public class ActionInfoController : Controller
    {
        //
        // GET: /ActionInfo/
        public IActionInfoBll actionInfoBll { set; get; }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPageList(int page, int rows)
        {
            int rowCount;
            var result = actionInfoBll.SelectByRow(rows, page, c => c.IsDelete == false, c => c.ActionId, out rowCount).
                Select(u => new { u.ActionId, u.ActionName,u.ActionTitle,u.ContorllerName,u.IsMenu,u.MenuIcon});
            return Json(new { total = rowCount, rows = result });
        }
        [HttpPost]
        public ActionResult Add(ActionInfo  model)
        {
            string result = "0";
            model.IsDelete = false;
            model.SubBy = 1;
            model.SubTime = DateTime.Now;
            bool b = actionInfoBll.Add(model);
            if (b)
            {
                result = "1";
            }
            return Content(result);
        }
        public ActionResult UploadMenu()
        {
            var requestFile = Request.Files["iconImg"];
            string imagePath = "/Upload/Images/";
            string fileName = imagePath + Guid.NewGuid().ToString() + requestFile.FileName;

            requestFile.SaveAs(Server.MapPath(fileName));

            return Content(fileName);
        }
        public ActionResult Remove(int id)
        {
            string result = "0";
            bool b = actionInfoBll.Delete(id);
            if (b)
            {
                result = "1";
            }
            return Content(result);
        }
        public ActionResult Edit(int id)
        {
            var model = actionInfoBll.Select(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ActionInfo  model)
        {
            string result = "0";
            model.IsDelete = false;
            model.SubBy= 1;
            model.SubTime = DateTime.Now;
            bool  b= actionInfoBll.Edit(model);
            if (b)
            {
                result = "1";
            }
            return Content(result);
        }
    }
}
