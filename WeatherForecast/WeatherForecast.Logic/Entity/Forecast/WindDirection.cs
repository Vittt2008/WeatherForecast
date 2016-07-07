using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	[XmlRoot("windDirection")]
	public class WindDirection
	{
		[XmlAttribute("deg")]
		public float Deg { get; set; }

		[XmlAttribute("code")]
		public string Code { get; set; }

		[XmlAttribute("name")]
		public string Name { get; set; }
	}
}