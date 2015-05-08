using BugManagement.IRepository;
using BugManagement.Persistence;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BugManagement.Repository.WindsorInstaller
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IRepository<>)).ImplementedBy(typeof(BaseRepository<>)).LifestyleTransient(),
                Component.For<BugManagementDbContext>().LifestyleSingleton(),
                Component.For<IUserRepository>().ImplementedBy<UserRepository>()
                );
        }
    }
}
