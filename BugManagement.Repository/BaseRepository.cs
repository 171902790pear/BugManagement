using System.Collections.Generic;
using BugManagement.IRepository;
using BugManagement.DomainModel;

namespace BugManagement.Repository
{
    public abstract class BaseRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
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
