using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	/// <summary>
	/// Информация о погоде в городе
	/// </summary>
	[XmlRoot("weatherdata")]
	public class WeatherData
	{
		[XmlElement("location")]
		public Location Location { get; set; }

		[XmlArray("forecast")]
		[XmlArrayItem("time")]
		public List<Time> Times { get; set; }

		public override string ToString()
		{
			return Location.ToString();
		}
	}
}