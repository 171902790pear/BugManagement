using BugManagement.UICommand;

namespace BugManagement.UIService
{
    public interface IUIService
    {
        void Signup(SignupCommand cmd);
        bool SignIn(string username, string password);

        bool CheckUsernameExist(string username);
    }
}
