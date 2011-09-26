using System.Collections.Generic;

namespace Typesafe.Web
{
	public interface IHttpClient
	{
		System.Net.HttpWebResponse ExecuteRequest(string method, string url, IDictionary<string, string> headers, object body);
	}
}