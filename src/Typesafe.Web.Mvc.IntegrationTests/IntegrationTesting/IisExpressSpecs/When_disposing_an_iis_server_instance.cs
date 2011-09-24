using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using Typesafe.Web.Mvc.IntegrationTesting;

namespace Typesafe.Web.Mvc.IntegrationTests.IntegrationTesting.IisExpressSpecs
{
	[TestFixture]
	public class When_disposing_an_iis_server_instance
	{
		public When_disposing_an_iis_server_instance()
		{
			new IisExpress("C:\\temp", 6845).Dispose();
		}
		
		[Test]
		public void the_server_should_be_stopped()
		{
			Assert.IsTrue(Process.GetProcessesByName("iisexpress").Length == 0);
		}
	}
}