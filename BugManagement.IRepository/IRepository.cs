using System.Collections.Generic;
using BugManagement.DomainModel;

namespace BugManagement.IRepository
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        void Save(TAggregateRoot tRoot);
        void Update(TAggregateRoot tRoot);

        TAggregateRoot Get();

        IEnumerable<TAggregateRoot> GetAll();

        void Delete(TAggregateRoot tRoot);
    }
}
