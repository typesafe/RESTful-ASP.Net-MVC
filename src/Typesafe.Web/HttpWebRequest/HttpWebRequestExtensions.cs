using System;
using System.Collections.Generic;
using System.IO;

namespace Typesafe.Web.HttpWebRequest
{
	public static class HttpWebRequestExtensions
	{
		public static void SetHeaders(this System.Net.HttpWebRequest request, IDictionary<string, string> headers)
		{
			if (headers == null) headers = new Dictionary<string, string>();

			foreach (var header in headers) request.SetHeader(header.Key, header.Value);
		}

		public static void SetHeader(this System.Net.HttpWebRequest request, string name, string value)
		{
			// TODO: see if there are more of these annoing constructs
			if (name == "Accept")
			{
				request.Accept = value;
				return;
			}

			request.Headers[name] = value;
		}

		public static void SetBody(this System.Net.HttpWebRequest request, object body)
		{
			if (body == null) return;
			
			if(body is string) SetBody(request, (string)body);

			else if (body is byte[]) SetBody(request, (byte[])body);

			else if (body is Stream) SetBody(request, (Stream)body);

			else throw new NotSupportedException("Only bodies of type string, byte[] or Stream can be set.");
		}

		private static void SetBody(this System.Net.HttpWebRequest request, string body)
		{
			using (var w = new StreamWriter(request.GetRequestStream()))
			{
				w.Write(body);
			}
		}

		private static void SetBody(this System.Net.HttpWebRequest request, byte[] body)
		{
			request.GetRequestStream().Write(body, 0, body.Length);
		}

		private static void SetBody(this System.Net.HttpWebRequest request, Stream body)
		{
			body.CopyTo(request.GetRequestStream());
		}
	}
}