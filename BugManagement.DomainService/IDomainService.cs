using System.Collections.Generic;
using BugManagement.DomainDto;

namespace BugManagement.DomainService
{
    public interface IDomainService
    {
        void CreateUser(UserDomainDto user);
        bool CheckUsernameExist(string username);
        bool CheckUserExist(UserDomainDto signInDto);
        List<ProjectDomainDto> GetProjects();
    }
}
