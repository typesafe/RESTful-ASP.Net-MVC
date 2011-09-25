using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Typesafe.Web.Mvc.IntegrationTesting
{
	public static class HttpWebRequestExtensions
	{
		public static void SetHeaders(this HttpWebRequest request, IDictionary<string, string> headers)
		{
			foreach (var header in headers ?? new Dictionary<string, string>()) request.SetHeader(header.Key, header.Value);
		}

		public static void SetHeader(this HttpWebRequest request, string name, string value)
		{
			request.Headers[name] = value;
		}

		public static void SetBody(this HttpWebRequest request, string body)
		{
			if (body == null) return;

			using (var w = new StreamWriter(request.GetRequestStream()))
			{
				w.Write(body);
			}
		}
	}
}