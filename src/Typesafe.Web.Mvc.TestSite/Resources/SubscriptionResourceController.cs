using System.Web.Mvc;
using Typesafe.Web.Mvc.Rest;

namespace Typesafe.Web.Mvc.TestSite.Resources
{
	[Resource("subscription")]
	public class SubscriptionResourceController : Controller
	{
		[RestOperation(HttpVerbs.Post, "")]
		public ActionResult Post()
		{
			return null;
		}

		[RestOperation(HttpVerbs.Get, "/{id}")]
		public ActionResult Get(int id)
		{
			return null;
			//return Representation(new SubscriptionRepresentation{Name = "foobar"});
		}
	}
}