using System.Web.Mvc;
using BugManagement.UICommand;
using BugManagement.UIService;

namespace BugManagement.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUIService _service;
        
        public AccountController(IUIService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(SignupCommand signupCommand)
        {
            _service.Signup(signupCommand);
            return View();
        }

    }
}
