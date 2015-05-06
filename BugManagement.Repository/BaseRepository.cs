using System.Collections.Generic;
using System.Data.Entity;
using BugManagement.IRepository;
using BugManagement.DomainModel;
using BugManagement.Persistence;
using Castle.Windsor;

namespace BugManagement.Repository
{
    public abstract class BaseRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        private readonly IWindsorContainer _windsorContainer;
        private DbContext _dbContext;
        protected BaseRepository(IWindsorContainer windsorContainer)
        {
            _windsorContainer = windsorContainer;
            _dbContext = _windsorContainer.Resolve<BugManagementDbContext>();
        }

        public void Save(TAggregateRoot tRoot)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TAggregateRoot tRoot)
        {
            throw new System.NotImplementedException();
        }

        public TAggregateRoot Get()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TAggregateRoot tRoot)
        {
            throw new System.NotImplementedException();
        }
    }
}
