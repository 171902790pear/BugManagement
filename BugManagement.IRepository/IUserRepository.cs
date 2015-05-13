using System.Security.Policy;
using BugManagement.DomainModel;

namespace BugManagement.IRepository
{
    public interface IUserRepository:IRepository<User>
    {
        User GetByUsername(string username);
        User GetByUsernameAndPassword(string username, string password);
    }
}
