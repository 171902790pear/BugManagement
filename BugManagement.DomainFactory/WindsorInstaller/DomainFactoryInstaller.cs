using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BugManagement.DomainFactory.WindsorInstaller
{
    public class DomainFactoryInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserFactory>().ImplementedBy<UserFactory>().LifestylePerWebRequest());
        }
    }
}
