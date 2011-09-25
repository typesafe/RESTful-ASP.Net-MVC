using System;
using System.Web.Mvc;

namespace Typesafe.Web.Mvc.Rest
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public class ResourceAttribute : Attribute
	{
		public ResourceAttribute(string baseUrl)
		{
			BaseUrl = baseUrl;
		}

		public string BaseUrl { get; private set; }
	}
}