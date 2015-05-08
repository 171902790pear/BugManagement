using System.Collections.Generic;
using System.Data.Entity;
using BugManagement.IRepository;
using BugManagement.DomainModel;
using BugManagement.Persistence;
using Castle.Windsor;

namespace BugManagement.Repository
{
    public class BaseRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : AggregateRootBase
    {
        private readonly IWindsorContainer _container;
        protected readonly DbContext _dbContext;
        public BaseRepository(IWindsorContainer container)
        {
            _container = container;
            _dbContext = _container.Resolve<BugManagementDbContext>();
        }

        public void Save(TAggregateRoot aggregateRoot)
        {
            _dbContext.Set<TAggregateRoot>().Add(aggregateRoot);
            _dbContext.SaveChanges();
        }

        public void Update(TAggregateRoot aggregateRoot)
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

        public void Delete(TAggregateRoot aggregateRoot)
        {
            throw new System.NotImplementedException();
        }
    }
}
