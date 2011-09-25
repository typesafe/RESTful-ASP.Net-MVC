using NUnit.Framework;
using Typesafe.Web.Mvc.Rest;

namespace Typesafe.Web.Mvc.UnitTests.Rest.XmlModelBinderPropvderSpecs
{
	[TestFixture]
	public class When_getting_the_binder_for_a_type_without_XMLRoot_attribute
	{
		[Test]
		public void the_provider_should_return_null()
		{
			Assert.IsNull(new XmlModelBinderProvider().GetBinder(typeof(string)));
		}
	}
}