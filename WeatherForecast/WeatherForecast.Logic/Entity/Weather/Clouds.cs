using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	/// <summary>
	/// Облака
	/// </summary>
	[XmlRoot("clouds")]
	public class Clouds
	{
		[XmlAttribute("value")]
		public string Value { get; set; }

		[XmlAttribute("name")]
		public string Name { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}