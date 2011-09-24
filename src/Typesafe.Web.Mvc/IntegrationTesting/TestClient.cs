using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Typesafe.Web.Mvc.IntegrationTesting
{
	public static class TestClient
	{
		private static IisExpress currentIisInstance;

		public static void InitializeServer(string physicalDirectory, int port)
		{
			if(currentIisInstance != null)
				currentIisInstance.Stop();

			currentIisInstance = new IisExpress(physicalDirectory, port);
		}

		//public static HttpWebResponse Get(string url, IDictionary<string, string> headers = null )
		//{
		//    return ExecuteRequest("GET", url, null, headers);
		//}

		//public static HttpWebResponse Post(string url, string body, IDictionary<string, string> headers = null)
		//{
		//    return ExecuteRequest("POST", url, body, headers);
		//}

		//private static HttpWebResponse ExecuteRequest(string method, string url, string body, IDictionary<string, string> headers)
		//{
		//    var request = (HttpWebRequest)WebRequest.Create("http://localhost:88/" + url);
		//    request.Method = method;

		//    request.SetHeaders(headers);
		//    request.SetBody(body);

		//    LogRequest(request, body);

		//    HttpWebResponse response = null;

		//    try
		//    {
		//        response = request.GetResponse() as HttpWebResponse;
		//    }
		//    catch (WebException ex)
		//    {
		//        response = ex.Response as HttpWebResponse;
		//    }

		//    LogResponse(response);

		//    return response;
		//}

		//private static void LogResponse(HttpWebResponse response)
		//{
		//    Console.WriteLine("\r\n# RESPONSE");
		//    Console.WriteLine("HTTP/1.1 {0} {1}", (int)response.StatusCode, response.StatusDescription);
		//    foreach (var key in response.Headers.AllKeys)
		//        Console.WriteLine("{0}: {1}", key, response.Headers[key]);

		//    Console.WriteLine("\r\n" + new StreamReader(response.GetResponseStream()).ReadToEnd());
		//}

		//private static void LogRequest(HttpWebRequest request, string body)
		//{
		//    Console.WriteLine("# REQUEST");
		//    Console.WriteLine("{0} {1} HTTP/1.1", request.Method, request.RequestUri);
		//    foreach (var key in request.Headers.AllKeys)
		//        Console.WriteLine("{0}: {1}", key, request.Headers[key]);

		//    if (body != null) Console.WriteLine("\r\n" + body);
		//}
	}
}