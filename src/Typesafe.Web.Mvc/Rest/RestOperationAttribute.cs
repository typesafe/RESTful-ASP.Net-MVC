using System;
using System.Reflection;
using System.Web.Mvc;

namespace Typesafe.Web.Mvc.Rest
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class RestOperationAttribute : ActionMethodSelectorAttribute
	{
		private readonly AcceptVerbsAttribute innerAttribute;

		public RestOperationAttribute(HttpVerbs httpVerb, string url)
		{
			innerAttribute = new AcceptVerbsAttribute(httpVerb);
			Url = url;
		}

		public string Url { get; set; }

		public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
		{
			return innerAttribute.IsValidForRequest(controllerContext, methodInfo);
		}
	}
}