using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	/// <summary>
	/// Скорость ветра
	/// </summary>
	[XmlRoot("windSpeed")]
	public class WindSpeed
	{
		[XmlAttribute("mps")]
		public float Mps { get; set; }

		[XmlAttribute("name")]
		public string Name { get; set; }

		public override string ToString()
		{
			return $"{Mps} m/s";
		}
	}
}