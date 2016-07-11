using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	/// <summary>
	/// Погода
	/// </summary>
	[XmlRoot("symbol")]
	public class Weather
	{
		[XmlAttribute("number")]
		public int Number { get; set; }

		[XmlAttribute("value")]
		public string Value { get; set; }

		public override string ToString()
		{
			return Value;
		}
	}
}