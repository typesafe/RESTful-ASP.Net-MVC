using System.Xml.Serialization;
using NUnit.Framework;
using Typesafe.Web.Mvc.Rest;

namespace Typesafe.Web.Mvc.UnitTests.Rest.XmlModelBinderPropvderSpecs
{
	[TestFixture]
	public class When_getting_the_binder_for_a_type_with_XMLRoot_attribute
	{
		[Test]
		public void the_provider_should_return_an_instance_of_XmlModelBinder()
		{
			Assert.IsInstanceOf<XmlModelBinder>(new XmlModelBinderProvider().GetBinder(typeof(Representation)));
		}

		[XmlRoot]
		private class Representation{}
	}
}