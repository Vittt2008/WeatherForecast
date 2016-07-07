using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	/// <summary>
	/// Осадки
	/// </summary>
	[XmlRoot("precipitation")]
	public class Precipitation
	{
		[XmlAttribute("value")]
		public float Value { get; set; }

		[XmlAttribute("type")]
		public string Type { get; set; }

		public override string ToString()
		{
			return Type;
		}
	}
}