using System.Collections.Generic;
using BugManagement.ApplicationDto;

namespace BugManagement.ApplicationService
{
    public interface IApplicationService
    {
        void Signup(SignupApplicationDto signup);
        bool CheckUsernameExist(string username);
        bool SignIn(SignInApplicationDto signInDto);
        List<ProjectApplicationDto> GetProjects();
    }
}
