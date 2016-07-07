using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	[XmlRoot("precipitation")]
	public class Precipitation
	{
		[XmlAttribute("value")]
		public float Value { get; set; }

		[XmlAttribute("mode")]
		public string Mode { get; set; }
	}
}