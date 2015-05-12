using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BugManagement.UnitOfWork.WindsorInstaller
{
    public class UnitOfWorkInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifestylePerWebRequest(),
                Component.For<IUnitOfWorkFactory>().ImplementedBy<IUnitOfWorkFactory>().LifestylePerWebRequest()
                );
        }
    }
}
