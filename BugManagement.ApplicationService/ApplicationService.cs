using System.Collections.Generic;
using BugManagement.ApplicationDto;
using BugManagement.Common;
using BugManagement.DomainDto;
using BugManagement.DomainService;

namespace BugManagement.ApplicationService
{
    public class ApplicationService : IApplicationService
    {
        private readonly IDomainService _domainService;

        public ApplicationService(IDomainService domainService)
        {
            _domainService = domainService;
        }

        public void Signup(SignupApplicationDto signup)
        {
            var dto = new UserDomainDto()
            {
                FirstName = signup.FirstName,
                LastName = signup.LastName,
                Username = signup.Username,
                Password = signup.Password
            };
            _domainService.CreateUser(dto);
        }

        public bool CheckUsernameExist(string username)
        {
            return _domainService.CheckUsernameExist(username);
        }

        public bool SignIn(SignInApplicationDto signInDto)
        {
            var dto = new UserDomainDto()
            {
                Username = signInDto.Username,
                Password = signInDto.Password
            };
            return _domainService.CheckUserExist(dto);
        }

        public List<ProjectApplicationDto> GetProjects()
        {
            var projectApplicationDtos = new List<ProjectApplicationDto>();
            var projectDomainDtos = _domainService.GetProjects();
            projectDomainDtos.ForEach(x => projectApplicationDtos.Add(x.ToProjectApplicationDto()));
            return projectApplicationDtos;
        }
    }


}