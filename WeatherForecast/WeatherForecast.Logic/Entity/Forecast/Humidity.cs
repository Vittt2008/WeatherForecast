using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	/// <summary>
	/// Влажность
	/// </summary>
	[XmlRoot("humidity")]
	public class Humidity
	{
		[XmlAttribute("value")]
		public int Value { get; set; }

		[XmlAttribute("unit")]
		public string Unit { get; set; }

		public override string ToString()
		{
			return $"{Value}{Unit}";
		}
	}
}