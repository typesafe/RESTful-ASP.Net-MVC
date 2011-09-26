using System.Xml.Serialization;

namespace Typesafe.Web.Mvc.TestSite.Representations
{
	[XmlRoot(ElementName = "subscription", Namespace = "http://typesafe.be/")]
	public class SubscriptionSubmission
	{
		[XmlElement("name")]
		public string Name { get; set; }
	}
}