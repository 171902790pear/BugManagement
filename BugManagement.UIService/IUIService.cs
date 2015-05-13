using BugManagement.UICommand;
using BugManagement.ViewModel;

namespace BugManagement.UIService
{
    public interface IUIService
    {
        void Signup(SignupCommand cmd);
        bool SignIn(SignInCommand cmd);

        bool CheckUsernameExist(string username);
        ProjectListViewModel GetProjectListViewModel();
    }
}
