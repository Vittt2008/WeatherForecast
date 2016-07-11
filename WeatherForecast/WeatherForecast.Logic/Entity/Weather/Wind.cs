using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	/// <summary>
	/// Ветер
	/// </summary>
	[XmlRoot("wind")]
	public class Wind
	{
		[XmlElement("speed")]
		public Speed Speed { get; set; }

		[XmlElement("direction")]
		public Direction Direction { get; set; }

		public override string ToString()
		{
			return $"{Speed}. {Direction}";
		}
	}
}