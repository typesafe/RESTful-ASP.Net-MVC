using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Typesafe.Web.HttpWebRequest;

namespace Typesafe.Web
{
	public class HttpClient : IHttpClient
	{
		public System.Net.HttpWebResponse ExecuteRequest(string method, string url, IDictionary<string, string> headers = null, object body = null)
		{
			var request = (System.Net.HttpWebRequest)WebRequest.Create(url);
			request.Method = method;

			request.SetHeaders(headers);
			request.SetBody(body);

			// LogRequest(request, body);

			System.Net.HttpWebResponse response = null;

			try
			{
				response = request.GetResponse() as System.Net.HttpWebResponse;
			}
			catch (WebException ex)
			{
				response = ex.Response as System.Net.HttpWebResponse;
			}

			// LogResponse(response);

			return response;
		}
	}
}
