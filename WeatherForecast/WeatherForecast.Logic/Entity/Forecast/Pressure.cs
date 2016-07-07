using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	[XmlRoot("pressure")]
	public class Pressure
	{
		[XmlAttribute("unit")]
		public string Unit { get; set; }

		[XmlAttribute("value")]
		public float Value { get; set; }
	}
}