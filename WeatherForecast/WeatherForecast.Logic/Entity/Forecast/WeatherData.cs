using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	[XmlRoot("weatherdata")]
	public class WeatherData
	{
		[XmlElement("location")]
		public Location Location { get; set; }

		[XmlArray("forecast")]
		[XmlArrayItem("time")]
		public List<Time> Times { get; set; }
	}
}