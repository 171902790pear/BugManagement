using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugManagement.DomainModel;
using BugManagement.IRepository;
using Castle.Windsor;

namespace BugManagement.Repository
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        public UserRepository(IWindsorContainer container)
            : base(container)
        {

        }
        public User GetByUsername(string username)
        {
            return _dbContext.Set<User>().SingleOrDefault(x => x.Username == username);
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return _dbContext.Set<User>().SingleOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
