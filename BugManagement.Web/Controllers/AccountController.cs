using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugManagement.UIService;

namespace BugManagement.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUIService _service;
        //
        // GET: /Account/
        public AccountController(IUIService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

    }
}
