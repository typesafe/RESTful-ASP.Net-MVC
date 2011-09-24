using System.Net;
using NUnit.Framework;
using Typesafe.Web.Mvc.IntegrationTesting;

namespace Typesafe.Web.Mvc.IntegrationTests.IntegrationTesting.TestClientSpecs
{
	[TestFixture]
	public class When_getting_a_resource_from_an_iis_express_hosted_app
	{
		private readonly HttpWebResponse response;

		public When_getting_a_resource_from_an_iis_express_hosted_app()
		{
			TestClient.InitializeServer("C:\\temp", 7823);
			response = TestClient.Get("foo");
		}

		[Test]
		public void a_proper_response_should_be_returned()
		{
			Assert.IsNotNull(response);
		}
	}
}
