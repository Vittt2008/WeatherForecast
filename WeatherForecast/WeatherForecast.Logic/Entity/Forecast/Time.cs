using System.Xml.Serialization;
using WeatherForecast.Logic.Entity.Forecast.Virtual;

namespace WeatherForecast.Logic.Entity.Forecast
{
	[XmlRoot("time")]
	public class Time
	{
		private DailyTime _dailyTime;
		private HoursTime _hoursTime;

		[XmlAttribute("day")]
		private string Day { get; set; }

		[XmlAttribute("from")]
		private string From { get; set; }

		[XmlAttribute("to")]
		private string To { get; set; }

		[XmlElement("symbol")]
		public Symbol Symbol { get; set; }

		[XmlElement("precipitation")]
		public Precipitation Precipitation { get; set; }

		[XmlElement("windDirection")]
		public WindDirection WindDirection { get; set; }

		[XmlElement("windSpeed")]
		public WindSpeed WindSpeed { get; set; }

		[XmlElement("temperature")]
		public Temperature Temperature { get; set; }

		[XmlElement("pressure")]
		public Pressure Pressure { get; set; }

		[XmlElement("humidity")]
		public Humidity Humidity { get; set; }

		[XmlElement("clouds")]
		public Clouds Clouds { get; set; }



		public DailyTime DailyTime => _dailyTime ?? (_dailyTime = new DailyTime(Day));
		public HoursTime HoursTime => _hoursTime ?? (_hoursTime = new HoursTime(From, To));
	}
}