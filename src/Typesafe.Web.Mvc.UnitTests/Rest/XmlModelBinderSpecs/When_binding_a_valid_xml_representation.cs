using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml.Serialization;
using NUnit.Framework;
using Typesafe.Web.Mvc.Rest;
using Typesafe.Web.Mvc.UnitTests.Builders;

namespace Typesafe.Web.Mvc.UnitTests.Rest.XmlModelBinderSpecs
{
	[TestFixture]
	public class When_binding_a_valid_xml_representation
	{
		private object result;

		public When_binding_a_valid_xml_representation()
		{
			IModelBinder binder = new XmlModelBinder();
			ControllerContext controllerContext = new ControllerContextBuilder()
				.WithInput(new MemoryStream(Encoding.UTF8.GetBytes("<rep xmlns='foo'><Prop>foobar</Prop></rep>")));

			result = binder.BindModel(controllerContext, new ModelBindingContextBuilder().ForModelOfType(typeof(Representation)));
		}

		[Test]
		public void the_created_object_should_not_be_null()
		{
			Assert.IsNotNull(result);
		}

		[Test]
		public void the_created_object_should_have_the_correct_values()
		{
			Assert.IsInstanceOf<Representation>(result);
			Assert.AreEqual("foobar", ((Representation)result).Prop);
		}
	}

	[XmlRoot("rep", Namespace = "foo")]
	public class Representation
	{
		public string Prop { get; set; }
	}
}