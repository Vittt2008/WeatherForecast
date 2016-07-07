using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	[XmlRoot("speed")]
	public class Speed
	{
		[XmlAttribute("value")]
		public float Value { get; set; }

		[XmlAttribute("name")]
		public string Name { get; set; }
	}
}