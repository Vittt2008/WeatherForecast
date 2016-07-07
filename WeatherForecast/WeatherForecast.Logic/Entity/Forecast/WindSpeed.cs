using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	[XmlRoot("windSpeed")]
	public class WindSpeed
	{
		[XmlAttribute("mps")]
		public float Mps { get; set; }

		[XmlAttribute("name")]
		public string Name { get; set; }
	}
}