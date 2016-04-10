using GitHubApi;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GitHubSearchRepository
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            SimpleInjectorRegistration();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

        private void SimpleInjectorRegistration()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            GitHubApiLibrary.Register(container);
            
            container.Verify();    
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
