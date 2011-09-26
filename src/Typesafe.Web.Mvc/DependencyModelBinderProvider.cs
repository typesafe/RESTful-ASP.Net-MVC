using System;
using System.Web.Mvc;

namespace Typesafe.Web.Mvc
{
	public class DependencyModelBinderProvider : IModelBinderProvider
	{
		public IModelBinder GetBinder(Type modelType)
		{
			return modelType.IsAbstract ? new DependencyModelBinder() : null;
		}
	}
}