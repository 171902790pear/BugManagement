using BugManagement.DomainDto;
using BugManagement.DomainFactory;
using BugManagement.IRepository;
using BugManagement.UnitOfWork;

namespace BugManagement.DomainService
{
    public class DomainService : IDomainService
    {
        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public DomainService(IUserFactory userFactory, IUserRepository userRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void CreateUser(UserDomainDto userDto)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork())
            {
                var user = _userFactory.Create(userDto);
                _userRepository.Save(user);
                unitOfWork.Commit();
            }
        }

        public bool CheckUsernameExist(string username)
        {
            var user = _userRepository.GetByUsername(username);
            return user != null;
        }
    }
}