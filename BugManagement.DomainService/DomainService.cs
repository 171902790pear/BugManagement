using System;
using System.Collections.Generic;
using BugManagement.Common;
using BugManagement.DomainDto;
using BugManagement.DomainFactory;
using BugManagement.DomainModel;
using BugManagement.IRepository;

namespace BugManagement.DomainService
{
    public class DomainService : IDomainService
    {
        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;

        public DomainService(IUserFactory userFactory, IUserRepository userRepository)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
        }

        public void CreateUser(UserDomainDto userDto)
        {
            var user = _userFactory.Create(userDto);
            _userRepository.Save(user);
        }

        public bool CheckUsernameExist(string username)
        {
            var user = _userRepository.GetByUsername(username);
            return user != null;
        }
    }
}