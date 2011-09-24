using System.Diagnostics;
using NUnit.Framework;
using Typesafe.Web.Mvc.IntegrationTesting;

namespace Typesafe.Web.Mvc.IntegrationTests.IntegrationTesting.IisExpressSpecs
{
	[TestFixture]
	public class When_creating_and_stopping_IIS_Express
	{
		private readonly bool startedJustFine;

		private readonly bool stoppedJustFine;
		
		public When_creating_and_stopping_IIS_Express()
		{
			try
			{
				var iisExpress = new IisExpress("C:\\temp", 6845);
				startedJustFine = Process.GetProcessesByName("iisexpress").Length == 1;

				iisExpress.Stop();

				stoppedJustFine = Process.GetProcessesByName("iisexpress").Length == 0;
			}
			catch { }
		}

		[Test]
		public void the_server_should_be_created()
		{
			Assert.IsTrue(startedJustFine);
		}

		[Test]
		public void the_server_should_be_stopped()
		{
			Assert.IsTrue(stoppedJustFine);
		}
	}
}