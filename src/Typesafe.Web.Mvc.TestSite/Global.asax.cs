using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Routing;
using Typesafe.Web.Mvc.Rest;

namespace Typesafe.Web.Mvc.TestSite
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}

		private static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new ShieldExceptions());
		}

		private static void RegisterRoutes(RouteCollection routes)
		{
			routes.RegisterResouces(BuildManager.GetReferencedAssemblies().Cast<Assembly>());
		}
	}
}