﻿using net.qunqun.zhaiqunOA.Bll;
using net.qunqun.zhaiqunOA.Common;
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
    public class UserController : Controller
    {
        //
        // GET: /User/
        public UserInfoManager userInfoBll { set; get; }
        public IRoleInfoBLL roleInfoBll { set; get; }
        public IActionInfoBll actionInfoBll { set; get; }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPageList(int page, int rows)
        { 
            //接受查询条件
            string uName = Request["uName"] ??"";
            string uTrueName = Request["uTrueName"] ??"";
            int rowCount;
                var result = userInfoBll.SelectByRow(rows, page,
                u => (u.IsDelete == false) &&
                (uName != "" ? u.UserName.Contains(uName) : true) &&
                 (uTrueName != "" ? u.UserTrueName.Contains(uTrueName) : true)
                , u => u.UserId, out rowCount).Select(u => new { u.UserId, u.UserName, u.UserTrueName });
        
            return Json(new { total = rowCount, rows = result },JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(UserInfo  model)
        {
            string result = "0";
            model.IsDelete = false;
            model.SubBy = 1;
            model.SubTime = DateTime.Now;
            model.UserPwd = Md5Helper.GetMd5(model.UserPwd);
            bool  b= userInfoBll.Add(model);
            if (b)
            {
                result = "1";
            }
            return Content(result);
        }

        public ActionResult Edit(int id)
        {
             UserInfo  model=  userInfoBll.Select(id);
              return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserInfo model)
        {
            string result = "0";
            model.SubBy = 1;
            model.SubTime = DateTime.Now;
            model.IsDelete = false;

            string pwd = Request["pwd"];
            if ( pwd!= Md5Helper.GetMd5(model.UserPwd))
            {
                model.UserPwd = Md5Helper.GetMd5(model.UserPwd);
            }
          bool  b=  userInfoBll.Edit(model);
            if (b)
            {
                result = "1";
            }
            return Content(result);
        }

        public ActionResult Remove(int id)
        {
            string result = "0";
             bool  b= userInfoBll.Delete(id);
             if (b)
             {
                 result = "1";
             }
             return Content(result);
        }
        public ActionResult SetRole(int id)
        {    
            SetRoleViewModel ur = new SetRoleViewModel();
            ur.UserModel = userInfoBll.Select(id);
            //ViewData["UserInfo"]= userInfoBll.Select(id);
            ur.RoleModels = roleInfoBll.Select(u => u.IsDelete == false).ToList();
             //ViewData.Model = roleInfoBll.Select(u => u.IsDelete == false).ToList();
            ViewData.Model = ur;
            return View();
        }
        [HttpPost]
        public ActionResult SetRole(int userId,string ids)
        {

       
            string result = "0";
            List<int> list = new List<int>();
            foreach (var id in ids.Split(','))
            {
                list.Add(int.Parse(id));
            }
            bool b = userInfoBll.SetRole(userId, list.ToArray());
            if (b)
            {
                result = "1";
            }
            return Content(result);
        }
        public ActionResult SetAction(int id)
        {
            SetActionViewModel model = new SetActionViewModel();
            model.UserModel = userInfoBll.Select(id);
            model.ActionModels = actionInfoBll.Select(u => u.IsDelete == false).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult SetAction(int userId, int actionId, int type)
        {

            string result = "0";
            bool b = userInfoBll.SetAction(userId, actionId, type);
             if (b)
             {
                 result = "1";
             }
            return Content(result);
        }
     
    }
}
