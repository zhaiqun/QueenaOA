using net.qunqun.zhaiqunOA.Bll;
using net.qunqun.zhaiqunOA.Model;
using net.qunqun.zhaiqunOA.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace net.qunqun.zhaiqunOA.UI.Controllers
{
    public class DepartInfoController : Controller
    {
        //
        // GET: /DepartInfo/
        public DepartInfoManager departInfoBll { set; get; }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDataList()
        {
            //List<DepartInfoViewModel> result = new List<DepartInfoViewModel>();
            List<DepartInfoViewModel> result = departInfoBll.Select(d => d.IsDelete == false).Select(u => new DepartInfoViewModel()
            {
                DepartId = u.DepartId,
                DepartName = u.DepartName,
                DepartParentId = u.DepartParentId
            }).ToList();
            List<DepartInfoViewModel> list = new List<DepartInfoViewModel>();

            var result1 = result.Where(r => r.DepartParentId == 0);
            foreach (var item1 in result1)
            {
                DepartInfoViewModel d1 = new DepartInfoViewModel()
                {
                    DepartId = item1.DepartId,
                    DepartName = item1.DepartName
                };
                list.Add(d1);        
                AddDepartInfo(result,d1);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public void AddDepartInfo(List<DepartInfoViewModel> result, DepartInfoViewModel departInfo)
        {
            var result1 = result.Where(r => r.DepartParentId== departInfo.DepartId);
            foreach (var item in result1)
            {
                DepartInfoViewModel d1 = new DepartInfoViewModel()
                {
                    DepartId=item.DepartId,
                    DepartName=item.DepartName,
                    DepartParentId=item.DepartParentId
                };
                departInfo.children.Add(d1);
                AddDepartInfo(result,d1);
            }
        }
        [HttpPost]
        public ActionResult Add(DepartInfo   model)
        { 
                //完善对象的初始值
            model.SubBy = 1;
            model.SubTime = DateTime.Now;
            model.IsDelete = false;     
            bool  b=  departInfoBll.Add(model);
            string result = "0";
            if (b)
            {
                result ="1";
            }
            return Content(result);
        }

        public ActionResult Edit(int id)
        {
            var model = departInfoBll.Select(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DepartInfo model)
        {
            string result = "0";
            model.SubBy = 1;
            model.SubTime = DateTime.Now;
            model.IsDelete = false;
           bool  b=  departInfoBll.Edit(model);
           if (b)
           {
               result = "1";
           }
           return Content(result);
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            string result = "0";
           bool  b=departInfoBll.Delete(id);
           if (b)
           {
               result = "1";
           }
           return Content(result);
        }
    }
}
