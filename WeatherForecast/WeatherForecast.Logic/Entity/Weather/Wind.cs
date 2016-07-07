using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	[XmlRoot("wind")]
	public class Wind
	{
		[XmlElement("speed")]
		public Speed Speed { get; set; }

		[XmlElement("direction")]
		public Direction Direction { get; set; }
	}
}