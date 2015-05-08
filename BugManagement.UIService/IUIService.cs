using BugManagement.UICommand;

namespace BugManagement.UIService
{
    public interface IUIService
    {
        void Signup(SignupCommand cmd);
        bool SignIn(SignInCommand cmd);

        bool CheckUsernameExist(string username);
    }
}
