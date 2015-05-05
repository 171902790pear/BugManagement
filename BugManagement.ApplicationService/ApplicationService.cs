using BugManagement.ApplicationDto;
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

        public void Signup(UserApplicationDto user)
        {
            var dto = new UserDomainDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password
            };
            _domainService.CreateUser(dto);
        }
    }
}