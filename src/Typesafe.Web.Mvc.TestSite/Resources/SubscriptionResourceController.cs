using System;
using System.Web.Mvc;
using Typesafe.Web.Mvc.Rest;
using Typesafe.Web.Mvc.TestSite.Representations;

namespace Typesafe.Web.Mvc.TestSite.Resources
{
	[Resource("subscription")]
	public class SubscriptionResourceController : Controller
	{
		[RestOperation(HttpVerbs.Post, "")]
		public ActionResult Post(SubscriptionSubmission subscription)
		{
			return new RepresentationResult(new Subscription { Name=  subscription.Name, SubmissionDate = DateTime.Now });
		}

		[RestOperation(HttpVerbs.Get, "/{id}")]
		public ActionResult Get(int id)
		{
			return id == 0 ? (ActionResult)HttpNotFound() : new RepresentationResult(new Subscription { Name = "foo", SubmissionDate = DateTime.Now });
		}
	}
}