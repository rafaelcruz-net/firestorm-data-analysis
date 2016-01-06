using Firestorm.Infra.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Firestorm.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            System.Web.Mvc.DependencyResolver.SetResolver(new Infra.IoC.NinjectDependencyResolver(Infra.IoC.Kernel.Instance));
        }

        public void Application_Error()
        {
            foreach (var task in Infra.IoC.Kernel.ResolveAllService<IRunOnError>())
            {
                task.Execute();
            }
        }

        public void Application_BeginRequest()
        {
            Task.Factory.StartNew(() =>
            {
                foreach (var task in Infra.IoC.Kernel.ResolveAllService<IRunBeforeEachRequest>())
                {
                    task.Execute();
                }
            });
        }

        public void Application_EndRequest()
        {
            Task.Factory.StartNew(() =>
            {
                foreach (var task in Infra.IoC.Kernel.ResolveAllService<IRunAfterEachRequest>())
                {
                    task.Execute();
                }
            });
        }
    }
}
