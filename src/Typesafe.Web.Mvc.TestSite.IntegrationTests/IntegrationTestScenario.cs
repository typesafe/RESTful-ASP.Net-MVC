using System.IO;
using System.Reflection;
using Typesafe.Web.Mvc.IntegrationTesting;

namespace Typesafe.Web.Mvc.TestSite.IntegrationTests
{
	public class IntegrationTestScenario
	{
		static IntegrationTestScenario()
		{
			// This assumes R# W/o shadow copying of assemblies
			var path = Path.Combine(Assembly.GetExecutingAssembly().Location, @"..\..\..\..\Typesafe.Web.Mvc.TestSite");
			path = @"C:\_git\RESTful-ASP.Net-MVC\src\Typesafe.Web.Mvc.TestSite";
			TestClient.InitializeServer(path, 9176);
		}
	}
}