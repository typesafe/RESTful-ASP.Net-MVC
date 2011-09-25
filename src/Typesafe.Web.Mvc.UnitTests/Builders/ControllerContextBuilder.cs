using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace Typesafe.Web.Mvc.UnitTests.Builders
{
	internal class ControllerContextBuilder
	{
		private readonly Mock<HttpRequestBase> requestMock = new Mock<HttpRequestBase>();
		private readonly Mock<HttpResponseBase> responseMock = new Mock<HttpResponseBase>();
		private readonly ControllerContext controllerContext;

		public ControllerContextBuilder()
		{
			var httpContextMock = new Mock<HttpContextBase>();
			httpContextMock.SetupGet(c => c.Request).Returns(requestMock.Object);
			httpContextMock.SetupGet(c => c.Response).Returns(responseMock.Object);

			WithRequestUrl("http://localhost/");

			controllerContext = new ControllerContext(httpContextMock.Object, new RouteData(), new Mock<ControllerBase>().Object);
		}

		public ControllerContextBuilder WithOutput(TextWriter output)
		{
			responseMock.SetupGet(c => c.Output).Returns(output);
			return this;
		}

		public ControllerContextBuilder WithInput(Stream input)
		{
			requestMock.SetupGet(c => c.InputStream).Returns(input);
			return this;
		}

		public ControllerContextBuilder WithRequestUrl(string url)
		{
			requestMock.SetupGet(c => c.Url).Returns(new Uri(url));
			return this;
		}

		public static ControllerContextBuilder CreateContext()
		{
			return new ControllerContextBuilder();
		}

		public static implicit operator ControllerContext(ControllerContextBuilder builder)
		{
			return builder.controllerContext;
		}
	}
}
