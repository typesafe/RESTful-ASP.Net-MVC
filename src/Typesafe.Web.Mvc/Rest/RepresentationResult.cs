using System.Linq;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Typesafe.Web.Mvc.Rest
{
	public class RepresentationResult : ActionResult
	{
		private readonly object model;

		public RepresentationResult(object model)
		{
			this.model = model;
		}

		public override void ExecuteResult(ControllerContext context)
		{
			var serializer = new XmlSerializer(model.GetType());
			serializer.Serialize(context.HttpContext.Response.Output, model);

			var expectedContentType = model.GetType().GetXmlRootNamespace();

			if (context.HttpContext.Request.AcceptTypes == null || !context.HttpContext.Request.AcceptTypes.Contains(expectedContentType))
				throw new UnsupportedContentTypeException(context.GetHeader("Accept"), expectedContentType);

			context.HttpContext.Response.ContentType = expectedContentType;
		}
	}
}