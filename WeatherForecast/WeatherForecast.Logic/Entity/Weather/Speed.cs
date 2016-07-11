using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Weather
{
	/// <summary>
	/// Скорость ветра
	/// </summary>
	[XmlRoot("speed")]
	public class Speed
	{
		[XmlAttribute("value")]
		public float Value { get; set; }

		[XmlAttribute("name")]
		public string Name { get; set; }

		public override string ToString()
		{
			return $"{Name}. {Value} m/s";
		}
	}
}