using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	/// <summary>
	/// Направление ветра
	/// </summary>
	[XmlRoot("direction")]
	public class Direction
	{
		[XmlAttribute("value")]
		public float Value { get; set; }

		[XmlAttribute("code")]
		public string Code { get; set; }

		[XmlAttribute("name")]
		public string Name { get; set; }

		public override string ToString()
		{
			return $"{Code} {Value}°";
		}
	}
}