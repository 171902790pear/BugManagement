using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;

namespace BugManagement.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetUnitOfWork();
    }


    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IWindsorContainer _container;

        public UnitOfWorkFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return _container.Resolve<IUnitOfWork>();
        }
    }
}
