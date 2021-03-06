﻿using System.Xml.Serialization;
using WeatherForecast.Logic.Entity.Forecast;

namespace WeatherForecast.Logic.Entity.Weather
{
	/// <summary>
	/// Текущая погода
	/// </summary>
	[XmlRoot("current")]
	public class CurrentWeather
	{
		[XmlElement("city")]
		public City City { get; set; }

		[XmlElement("temperature")]
		public Temperature Temperature { get; set; }

		[XmlElement("humidity")]
		public Humidity Humidity { get; set; }

		[XmlElement("pressure")]
		public Pressure Pressure { get; set; }

		[XmlElement("wind")]
		public Wind Wind { get; set; }

		[XmlElement("clouds")]
		public Clouds Clouds { get; set; }

		[XmlElement("precipitation")]
		public Precipitation Precipitation { get; set; }

		[XmlElement("weather")]
		public Weather Weather { get; set; }

		[XmlElement("lastupdate")]
		public LastUpdate LastUpdate { get; set; }

		public override string ToString()
		{
			return $"{City} {Temperature}";
		}
	}
}