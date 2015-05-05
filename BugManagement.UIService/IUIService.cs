using BugManagement.UICommand;

namespace BugManagement.UIService
{
    public interface IUIService
    {
        void Signup(SignupCommand cmd);
        bool CheckUserIsExist(string username, string password);
    }
}
