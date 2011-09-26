using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Typesafe.Web.Mvc.Rest;

namespace Typesafe.Web.Mvc.IntegrationTesting
{
	public static class TestClient
	{
		private static IisExpress currentIisInstance;
		private static int currentPort;

		public static void InitializeServer(string physicalDirectory, int port)
		{
			if(currentIisInstance != null)
				currentIisInstance.Stop();

			currentPort = port;
			currentIisInstance = new IisExpress(physicalDirectory, port);
		}

		public static System.Net.HttpWebResponse Get(string url, IDictionary<string, string> headers = null)
		{
			return ExecuteRequest("GET", url, null, headers);
		}

		public static System.Net.HttpWebResponse Post(string url, string body, IDictionary<string, string> headers = null)
		{
			return ExecuteRequest("POST", url, body, headers);
		}

		private static System.Net.HttpWebResponse ExecuteRequest(string method, string url, string body, IDictionary<string, string> headers)
		{
			return new HttpClient().ExecuteRequest(method, url, headers, body);
		}

		private static void LogResponse(System.Net.HttpWebResponse response)
		{
			Console.WriteLine("\r\n# RESPONSE");
			Console.WriteLine("HTTP/1.1 {0} {1}", (int)response.StatusCode, response.StatusDescription);
			foreach (var key in response.Headers.AllKeys)
				Console.WriteLine("{0}: {1}", key, response.Headers[key]);

			Console.WriteLine("\r\n" + new StreamReader(response.GetResponseStream()).ReadToEnd());
		}

		private static void LogRequest(System.Net.HttpWebRequest request, string body)
		{
			Console.WriteLine("# REQUEST");
			Console.WriteLine("{0} {1} HTTP/1.1", request.Method, request.RequestUri);
			foreach (var key in request.Headers.AllKeys)
				Console.WriteLine("{0}: {1}", key, request.Headers[key]);

			if (body != null) Console.WriteLine("\r\n" + body);
		}
	}
}