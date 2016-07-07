using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	/// <summary>
	/// Город
	/// </summary>
	[XmlRoot("city")]
	public class City
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlElement("country")]
		public string Country { get; set; }

		public override string ToString()
		{
			return $"{Name}, {Country}";
		}
	}
}