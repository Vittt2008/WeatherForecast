using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	/// <summary>
	/// Облачность
	/// </summary>
	[XmlRoot("clouds")]
	public class Clouds
	{
		[XmlAttribute("value")]
		public string Value { get; set; }

		[XmlAttribute("all")]
		public int All { get; set; }

		[XmlAttribute("unit")]
		public string Unit { get; set; }

		public override string ToString()
		{
			return $"{All}{Unit}";
		}
	}
}