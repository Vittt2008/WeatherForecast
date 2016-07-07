using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	[XmlRoot("symbol")]
	public class Weather
	{
		[XmlAttribute("number")]
		public int Number { get; set; }

		[XmlAttribute("value")]
		public string Value { get; set; }
	}
}