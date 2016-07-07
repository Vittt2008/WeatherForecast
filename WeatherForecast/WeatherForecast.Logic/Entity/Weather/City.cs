using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	[XmlRoot("city")]
	public class City
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlElement("country")]
		public string Country { get; set; }
	}
}