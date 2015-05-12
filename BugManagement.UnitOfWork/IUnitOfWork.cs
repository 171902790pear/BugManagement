using System;
using System.Data.Entity;
using BugManagement.Persistence;
using Castle.Windsor;

namespace BugManagement.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IWindsorContainer _container;
        private readonly DbContext _dbContext;

        public UnitOfWork(IWindsorContainer container)
        {
            _container = container;
            _dbContext = _container.Resolve<BugManagementDbContext>();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
