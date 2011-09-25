using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace Typesafe.Web.Mvc.Rest
{
	public static class RouteExtensions
	{
		public static void RegisterResouces(this RouteCollection routes, IEnumerable<Assembly> assemblies)
		{
			foreach (var type in GetResourceTypes(assemblies))
			{
				var baseUrl = new Uri(type.GetAttribute<ResourceAttribute>().BaseUrl, UriKind.Relative);

				foreach (var method in GetRestOperations(type))
				{
					routes.MapRoute(
						string.Format("{0}.{1}", type.Name, method.Name),
						baseUrl + method.GetAttribute<RestOperationAttribute>().Url,
						new { controller = type.Name.Replace("Controller", ""), action = method.Name });
				}
			}
		}

		private static IEnumerable<MethodInfo> GetRestOperations(IReflect type)
		{
			return type
				.GetMethods(BindingFlags.Instance | BindingFlags.Public)
				.Where(m => m.HasAttribute<RestOperationAttribute>());
		}

		private static IEnumerable<Type> GetResourceTypes(IEnumerable<Assembly> assemblies)
		{
			return assemblies.SelectMany(a => a.GetTypes()).Where(t => t.HasAttribute<ResourceAttribute>());
		}
	}
}