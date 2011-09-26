using System;
using System.Xml.Serialization;

namespace Typesafe.Web.Mvc.TestSite.Representations
{
	[XmlRoot(ElementName = "subscription", Namespace = "http://typesafe.be/")]
	public class Subscription
	{
		[XmlElement("name")]
		public string Name { get; set; }

		[XmlElement("submissionDate")]
		public DateTime SubmissionDate { get; set; }
	}
}