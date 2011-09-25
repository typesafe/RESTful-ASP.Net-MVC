using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;
using Typesafe.Web.Mvc.Rest;

namespace Typesafe.Web.Mvc.UnitTests.Rest.RouteExtensionsSpecs
{
	[TestFixture]
	public class When_registering_resource_routes
	{
		private RouteCollection routes;

		public When_registering_resource_routes()
		{
			routes = new RouteCollection();

			routes.RegisterResouces(new[] {Assembly.GetExecutingAssembly()});
		}

		[Test]
		public void the_resource_operations_should_be_registered()
		{
			Assert.AreEqual(1, routes.Count);
		}

		[Test]
		public void the_resource_route_should_refer_to_correct_controller()
		{
			Assert.AreEqual("TestResource", ((Route)routes.First()).Defaults["controller"]);
		}

		[Test]
		public void the_resource_route_should_refer_to_correct_action()
		{
			Assert.AreEqual("Get", ((Route)routes.First()).Defaults["action"]);
		}

		[Test]
		public void the_resource_route_should_be_for_the_full_url()
		{
			Assert.AreEqual("foo/{id}", ((Route)routes.First()).Url);
		}
	}

	[Resource("foo")]
	public class TestResourceController : Controller
	{
		[RestOperation(HttpVerbs.Get, "/{id}")]
		public ActionResult Get(int id)
		{
			return null;
		}
	}
}