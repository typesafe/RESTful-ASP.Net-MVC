using System.Diagnostics;
using NUnit.Framework;
using Typesafe.Web.Mvc.IntegrationTesting;

namespace Typesafe.Web.Mvc.IntegrationTests.IntegrationTesting.TestClientSpecs
{
	[TestFixture]
	public class When_initializing_the_test_client
	{
		[Test]
		public void an_iis_express_instance_should_run()
		{
			TestClient.InitializeServer("c:\\temp", 9176);

			Assert.IsTrue(Process.GetProcessesByName("iisexpress").Length == 1);
		}
	}
}