using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	[XmlRoot("location")]
	public class Location
	{
		[XmlAttribute("name")]
		public string City { get; set; }

		[XmlAttribute("country")]
		public string Country { get; set; }
	}
}