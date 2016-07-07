using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	/// <summary>
	/// Направление ветра
	/// </summary>
	[XmlRoot("windDirection")]
	public class WindDirection
	{
		[XmlAttribute("deg")]
		public float Deg { get; set; }

		[XmlAttribute("code")]
		public string Code { get; set; }

		[XmlAttribute("name")]
		public string Name { get; set; }

		public override string ToString()
		{
			return $"{Code} {Deg}°";
		}
	}
}