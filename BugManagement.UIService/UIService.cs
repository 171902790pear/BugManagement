using System;
using BugManagement.ApplicationDto;
using BugManagement.ApplicationService;
using BugManagement.UICommand;

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
            var user = new UserApplicationDto()
            {
                FirstName = cmd.FirstName,
                LastName = cmd.LastName,
                Username = cmd.Username,
                Password = cmd.Password
            };
            _applicationService.Signup(user);
        }

        public bool SignIn(SignInCommand cmd)
        {
            throw new NotImplementedException();
        }

        public bool CheckUsernameExist(string username)
        {
            return _applicationService.CheckUsernameExist(username);
        }
    }
}