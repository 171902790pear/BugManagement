using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BugManagement.ApplicationService.WindsorInstaller;
using BugManagement.DomainFactory.WindsorInstaller;
using BugManagement.DomainService.WindsorInstaller;
using BugManagement.Repository.WindsorInstaller;
using BugManagement.UIService.WindsorInstaller;
using BugManagement.Web.WindsorInstaller;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace BugManagement.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new WindsorContainer();
            container.Register(Component.For<IWindsorContainer>().Instance(container).LifestylePerWebRequest());
            container.Install(
                FromAssembly.This(),
                FromAssembly.Containing<UIServiceInstaller>(),
                FromAssembly.Containing<ApplicationServiceInstaller>(),
                FromAssembly.Containing<DomainServiceInstaller>(),
                FromAssembly.Containing<DomainFactoryInstaller>(),
                FromAssembly.Containing<RepositoryInstaller>()
                );
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }
}