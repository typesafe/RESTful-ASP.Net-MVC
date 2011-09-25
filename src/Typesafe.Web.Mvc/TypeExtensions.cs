using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Typesafe.Web.Mvc
{
	public static class ReflectionExtensions
	{
		public static bool HasAttribute<T>(this ICustomAttributeProvider attributeProvider)
		{
			return attributeProvider.GetCustomAttributes(typeof(T), true).Any();
		}

		public static T GetAttribute<T>(this ICustomAttributeProvider attributeProvider)
		{
			return (T)attributeProvider.GetCustomAttributes(typeof(T), true).FirstOrDefault();
		}
		
		public static string GetXmlRootNamespace(this Type type)
		{
			return type.GetAttribute<XmlRootAttribute>().Namespace;
		}
	}
}