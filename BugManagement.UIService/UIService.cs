using System.Collections.Generic;
using BugManagement.ApplicationDto;
using BugManagement.ApplicationService;
using BugManagement.Common;
using BugManagement.UICommand;
using BugManagement.ViewModel;

namespace BugManagement.UIService
{
    public class UIService : IUIService
    {
        private readonly IApplicationService _applicationService;

        public UIService(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public void Signup(SignupCommand cmd)
        {
            var signupDto = new SignupApplicationDto()
            {
                FirstName = cmd.FirstName,
                LastName = cmd.LastName,
                Username = cmd.Username,
                Password = cmd.Password
            };
            _applicationService.Signup(signupDto);
        }

        public bool SignIn(SignInCommand cmd)
        {
            var signInDto = new SignInApplicationDto()
                            {
                                Username = cmd.Username,
                                Password = cmd.Password
                            };
            return _applicationService.SignIn(signInDto);
        }

        public bool CheckUsernameExist(string username)
        {
            return _applicationService.CheckUsernameExist(username);
        }

        public ProjectListViewModel GetProjectListViewModel()
        {
            var projectDtos = _applicationService.GetProjects();
            var projects = new List<ProjectListViewModel.Project>();
            projectDtos.ForEach(x => projects.Add(x.ToProjectViewModel()));
            return new ProjectListViewModel()
                   {
                       Projects = projects
                   };
        }
    }
}