using System;
using BugManagement.DomainDto;
using BugManagement.DomainFactory;
using BugManagement.DomainModel;
using BugManagement.IRepository;

namespace BugManagement.DomainService
{
    public class DomainService : IDomainService
    {
        private readonly IUserFactory _userFactory;
        private readonly IRepository<User> _userRepository;

        public DomainService(IUserFactory userFactory,IRepository<User> userRepository)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
        }

        public void CreateUser(UserDomainDto userDto)
        {
            var user = _userFactory.Create(userDto);
            _userRepository.Save(user);
        }
    }
}