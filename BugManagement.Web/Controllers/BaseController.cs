using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugManagement.Common;
using BugManagement.Web.Models;

namespace BugManagement.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnException(ExceptionContext exceptionContext)
        {
            var exception = exceptionContext.Exception as ErrorException;
            if ( exception!= null)
            {
                var jsonReuslt = Json(new 
                                      {
                                          Success = false,
                                          Errors = exception.Errors
                                      });
                exceptionContext.Result = jsonReuslt;
                exceptionContext.ExceptionHandled = true;
                exceptionContext.HttpContext.Response.StatusCode = 200;
            }
            base.OnException(exceptionContext);
        }


        public ActionResult SuccessResult()
        {
            return Json(new {Success=true});
        }
    }
}
