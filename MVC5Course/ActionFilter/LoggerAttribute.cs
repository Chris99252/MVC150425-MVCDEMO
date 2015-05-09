using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.ActionFilter
{
    public class LoggerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Trace.TraceInformation("OnActionExecuting Log Begin");
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Trace.TraceInformation("OnActionExecuted Log End");
            base.OnActionExecuted(filterContext);
        }
    }
}