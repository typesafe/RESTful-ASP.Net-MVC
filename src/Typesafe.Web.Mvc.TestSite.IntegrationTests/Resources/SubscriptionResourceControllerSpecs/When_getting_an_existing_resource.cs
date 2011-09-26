using System.Collections.Generic;
using System.Net;
using NUnit.Framework;
using Typesafe.Web.Mvc.IntegrationTesting;

namespace Typesafe.Web.Mvc.TestSite.IntegrationTests.Resources.SubscriptionResourceControllerSpecs
{
	[TestFixture]
	public class When_getting_an_existing_resource: IntegrationTestScenario
	{
		[Test]
		public void the_corresponding_representation_should_be_returned()
		{
			Assert.AreEqual(HttpStatusCode.OK, TestClient.Get("subscription/123", new Dictionary<string, string> { { "Accept", "http://typesafe.be/" } }).StatusCode);
		}
	}

	[TestFixture]
	public class When_getting_an_non_existing_resource : IntegrationTestScenario
	{
		[Test]
		public void the_corresponding_representation_should_be_returned()
		{
			Assert.AreEqual(HttpStatusCode.NotFound, TestClient.Get("subscription/0", new Dictionary<string, string> { { "Accept", "http://typesafe.be/" } }).StatusCode);
		}
	}
}