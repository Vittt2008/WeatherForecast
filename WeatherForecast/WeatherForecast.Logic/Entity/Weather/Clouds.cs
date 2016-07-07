using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	[XmlRoot("clouds")]
	public class Clouds
	{
		[XmlAttribute("value")]
		public string Value { get; set; }

		[XmlElement("name")]
		public string Name { get; set; }
	}
}