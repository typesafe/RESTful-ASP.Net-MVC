using System;
using System.IO;
using NUnit.Framework;
using Typesafe.Web.Mvc.IntegrationTesting;

namespace Typesafe.Web.Mvc.IntegrationTests.IntegrationTesting.IisExpressSpecs
{
	[TestFixture]
	public class When_creating_an_IIS_Express_instance_for_a_non_existing_physical_directory
	{
		private readonly bool directoryNotFound;

		public When_creating_an_IIS_Express_instance_for_a_non_existing_physical_directory()
		{
			try
			{
				new IisExpress("C:\\" + Guid.NewGuid(), 6845);
			}
			catch (DirectoryNotFoundException)
			{
				directoryNotFound = true;
			}
		}

		[Test]
		public void a_DirectoryNotFoundException_should_be_thrown()
		{
			Assert.IsTrue(directoryNotFound);
		}
	}
}