using System;

namespace Typesafe.Web.Mvc.Rest
{
	public class UnsupportedContentTypeException : Exception
	{
		public UnsupportedContentTypeException(string contentType, string expectedContentType) 
			: base(string.Format("The specified content type '{0}' is not supported. Expected content type is '{1}'.", contentType, expectedContentType))
		{
			ContentType = contentType;
			ExpectedContentType = expectedContentType;
		}

		public string ContentType { get; private set; }

		public string ExpectedContentType { get; private set; }
	}
}