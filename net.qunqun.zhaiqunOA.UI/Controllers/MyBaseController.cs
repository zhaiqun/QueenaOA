using net.qunqun.zhaiqunOA.Common;
using net.qunqun.zhaiqunOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace net.qunqun.zhaiqunOA.UI.Controllers
{
    public class MyBaseController : Controller
    {

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //if (filterContext.HttpContext.Session["UserLogin"] == null)
            //{
            //    filterContext.Result = new RedirectResult(Url.Action("Index", "UserLogin"));
            //}
            if (filterContext.HttpContext.Request.Cookies["userId"]== null)
            {
                filterContext.Result = new RedirectResult(Url.Action("Index", "UserLogin"));
            }
            else
            {
                string key = filterContext.HttpContext.Request.Cookies["userId"].Value.ToString();

                var userlogin = MMhelper.Get(key) as UserLogin;
                if (userlogin == null)
                {
                    filterContext.Result = new RedirectResult(Url.Action("Index", "UserLogin"));
                    return;
                }
                filterContext.HttpContext.Response.Cookies["userId"].Expires = DateTime.Now.AddDays(20);
                MMhelper.Set(key, userlogin, DateTime.Now.AddMinutes(20));
            }

        }
    }
}
