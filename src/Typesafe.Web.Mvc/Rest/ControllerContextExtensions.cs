using System.Web.Mvc;

namespace Typesafe.Web.Mvc.Rest
{
	public static class ControllerContextExtensions
	{
		public static string GetHeader(this ControllerContext context, string name)
		{
			return context.HttpContext.Request.Headers[name];
		}

		public static string SetHeader(this ControllerContext context, string name, string value)
		{
			return context.HttpContext.Request.Headers[name] = value;
		}
	}
}