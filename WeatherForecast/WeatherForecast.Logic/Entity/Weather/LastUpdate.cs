using System;
using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	[XmlRoot("lastupdate")]
	public class LastUpdate
	{
		[XmlAttribute("value")]
		public DateTime Value { get; set; }

		public DateTime LocalTime => Value.ToLocalTime();

		public override string ToString()
		{
			return LocalTime.ToString();
		}
	}
}