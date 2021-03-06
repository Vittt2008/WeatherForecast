﻿using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	/// <summary>
	/// Осадки
	/// </summary>
	[XmlRoot("precipitation")]
	public class Precipitation
	{
		[XmlAttribute("value")]
		public float Value { get; set; }

		[XmlAttribute("mode")]
		public string Mode { get; set; }

		public override string ToString()
		{
			return Mode;
		}
	}
}