using net.qunqun.zhaiqunOA.Bll;
using net.qunqun.zhaiqunOA.Common;
using net.qunqun.zhaiqunOA.Model;
using net.qunqun.zhaiqunOA.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace net.qunqun.zhaiqunOA.UI.Controllers
{
    public class UserLoginController : Controller
    {
        //
        // GET: /UserLogin/
        public ActionResult Logout()
        {
            //Session["UserLogin"] =null;
            Response.Cookies["userId"].Expires = DateTime.Now.AddSeconds(-1);
            string key = Request.Cookies["userId"].Value.ToString();
            MMhelper.Delete(key);
           
            return new RedirectResult(Url.Action("Index", "UserLogin"));
        }
        public UserInfoManager userInfoBll { set; get; }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetValicode()
        { 
            ValidateCode vCode=new ValidateCode();
            string   code=vCode.CreateValidateCode(5);
            Session["validateCode"] = code;
            byte[]  bs=vCode.CreateValidateGraphic(code);
            return File(bs, @"image/jpeg");
        }
        public ActionResult Login(UserLoginFormModel   userModel)
        {
            string result = "fail";
            //对比验证码
            if (Session["validateCode"].Equals(userModel.ValidateCode))
            {
                UserLogin loginModel = new UserLogin() { UName=userModel.UName,UPwd=Md5Helper.GetMd5( userModel.UPwd)};
                 bool loginOk= userInfoBll.Login(loginModel);
                 if (loginOk)
                 {
                     result = "yes";
                     //Session["UserLogin"] = loginModel;
                     //使用mm+cookie进行登录用户的存储
                     string key = Guid.NewGuid().ToString();
                     MMhelper.Set(key,loginModel,DateTime.Now.AddMinutes(20));
                     HttpCookie cookie = new HttpCookie("userId");
                     cookie.Value = key;
                     cookie.Expires = DateTime.Now.AddMinutes(20);
                     Response.Cookies.Add(cookie);
                     
                 }
                 else
                 {
                     result = "no";
                 }
            }
            else
            {
                result = "validateFail";
            }
            return Content(result);
        }
    }
}
