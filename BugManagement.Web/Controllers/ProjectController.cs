using System.Web.Mvc;
using BugManagement.UIService;

namespace BugManagement.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IUIService _service;

        public ProjectController(IUIService service)
        {
            _service = service;
        }
        public ActionResult List()
        {
            var projectListViewModel = _service.GetProjectListViewModel();
            return View(projectListViewModel);
        }

    }
}
