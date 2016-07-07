using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	/// <summary>
	/// Давление
	/// </summary>
	[XmlRoot("pressure")]
	public class Pressure
	{
		[XmlAttribute("unit")]
		public string Unit { get; set; }

		[XmlAttribute("value")]
		public float Value { get; set; }

		public override string ToString()
		{
			return $"{Value} {Unit}";
		}
	}
}