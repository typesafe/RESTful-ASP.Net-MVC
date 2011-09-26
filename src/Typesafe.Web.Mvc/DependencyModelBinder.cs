using System.Web.Mvc;

namespace Typesafe.Web.Mvc
{
	public class DependencyModelBinder : IModelBinder
	{
		object IModelBinder.BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			return DependencyResolver.Current.GetService(bindingContext.ModelType);
		}
	}
}