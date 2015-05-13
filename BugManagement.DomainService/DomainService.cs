using System.Collections.Generic;
using System.Linq;
using BugManagement.Common;
using BugManagement.DomainDto;
using BugManagement.DomainFactory;
using BugManagement.DomainModel;
using BugManagement.IRepository;
using BugManagement.UnitOfWork;

namespace BugManagement.DomainService
{
    public class DomainService : IDomainService
    {
        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRepository<Project> _projectRepository;

        public DomainService(IUserFactory userFactory, IUserRepository userRepository, IUnitOfWorkFactory unitOfWorkFactory, IRepository<Project> projectRepository)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
            _projectRepository = projectRepository;
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

        public bool CheckUserExist(UserDomainDto signInDto)
        {
            var user = _userRepository.GetByUsernameAndPassword(signInDto.Username, signInDto.Password);
            return user != null;
        }

        public List<ProjectDomainDto> GetProjects()
        {
            var projectDomainDtos = new List<ProjectDomainDto>();
            var projects = _projectRepository.GetAll().ToList();
            projects.ForEach(x => projectDomainDtos.Add(x.ToProjectDomainDto()));
            return projectDomainDtos;
        }
    }
}