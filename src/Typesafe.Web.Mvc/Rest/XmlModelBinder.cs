using System.Web.Mvc;
using System.Xml.Serialization;

namespace Typesafe.Web.Mvc.Rest
{
	public class XmlModelBinder : IModelBinder
	{
		object IModelBinder.BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			//var expectedContentType = bindingContext.ModelType.GetXmlRootNamespace();

			//if (controllerContext.GetHeader("Content-Type") != expectedContentType)
			//    throw new UnsupportedContentTypeException(controllerContext.GetHeader("Content-Type"), expectedContentType);

			//// TODO: use validating xml reader and throw if errors found

			var serializer = new XmlSerializer(bindingContext.ModelType);
			return serializer.Deserialize(controllerContext.HttpContext.Request.InputStream);
		}
	}
}