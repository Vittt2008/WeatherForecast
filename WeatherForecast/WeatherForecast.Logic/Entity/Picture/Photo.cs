using System;
using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Picture
{
	[XmlRoot("photo")]
	public class Photo
	{
		[XmlAttribute("id")]
		public string Id { get; set; }

		[XmlAttribute("secret")]
		public string Secret { get; set; }

		[XmlAttribute("server")]
		public string Server { get; set; }

		[XmlAttribute("farm")]
		public string Farm { get; set; }

		[XmlAttribute("title")]
		public string Title { get; set; }

		public string PhotoUrl => $"https://farm{Farm}.staticflickr.com/{Server}/{Id}_{Secret}.jpg";
	}
}