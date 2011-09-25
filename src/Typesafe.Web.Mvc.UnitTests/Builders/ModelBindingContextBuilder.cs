using System;
using System.Web.Mvc;

namespace Typesafe.Web.Mvc.UnitTests.Builders
{
	internal class ModelBindingContextBuilder
	{
		private readonly ModelBindingContext modelBindingContext;

		public ModelBindingContextBuilder()
		{
			modelBindingContext = new ModelBindingContext();
		}

		public ModelBindingContext ForModelOfType(Type type)
		{
			modelBindingContext.ModelMetadata = 
				new ModelMetadata(new DataAnnotationsModelMetadataProvider(), typeof(Type), () => null, type, "foo");

			return this;
		}

		public static implicit operator ModelBindingContext(ModelBindingContextBuilder builder)
		{
			return builder.modelBindingContext;
		}
	}
}