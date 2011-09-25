using System;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Typesafe.Web.Mvc.Rest
{
	public class XmlModelBinderProvider : IModelBinderProvider
	{
		public IModelBinder GetBinder(Type modelType)
		{
			return modelType.GetCustomAttributes(typeof(XmlRootAttribute), false).Length == 1
			       	? new XmlModelBinder()
			       	: null;
		}
	}
}