using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace net.qunqun.zhaiqunOA.UI.Models
{
    public class MyExceptionHandlerAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Common.LogHelper.MessageEnqueue(filterContext.Exception.Message);
            filterContext.Result = new RedirectResult("/error.html");
        }
    }
}