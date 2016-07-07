using System;
using System.Xml.Serialization;
using WeatherForecast.Logic.Entity.Forecast.Virtual;

namespace WeatherForecast.Logic.Entity.Forecast
{
	/// <summary>
	/// Температура
	/// </summary>
	[XmlRoot("temperature")]
	public class Temperature
	{
		private HoursTemperature _hoursTemperature;
		private DailyTemperature _dailyTemperature;

		[XmlAttribute("unit")]
		public string Unit { get; set; }

		[XmlAttribute("day")]
		public float Day { get; set; }

		[XmlAttribute("min")]
		public float Min { get; set; }

		[XmlAttribute("max")]
		public float Max { get; set; }

		[XmlAttribute("night")]
		public float Night { get; set; }

		[XmlAttribute("eve")]
		public float Eve { get; set; }

		[XmlAttribute("morn")]
		public float Morn { get; set; }

		[XmlAttribute("value")]
		public float Value { get; set; }

		public DailyTemperature DailyTemperature => _dailyTemperature ?? (_dailyTemperature = new DailyTemperature(Unit, Day, Min, Max, Night, Eve, Morn));

		public HoursTemperature HoursTemperature => _hoursTemperature ?? (_hoursTemperature = new HoursTemperature(Unit, Value, Min, Max));

		public override string ToString()
		{
			var temperature = Math.Abs(Value) > 10E-4 ? Value : Day;
			return $"{temperature}°C";
		}
	}
}