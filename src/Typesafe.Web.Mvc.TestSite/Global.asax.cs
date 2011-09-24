using System.Web.Mvc;
using System.Web.Routing;

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
			filters.Add(new HandleErrorAttribute());
		}

		private static void RegisterRoutes(RouteCollection routes)
		{
		}
	}
}