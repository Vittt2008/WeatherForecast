using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	/// <summary>
	/// Краткая погода
	/// </summary>
	[XmlRoot("symbol")]
	public class Symbol
	{
		[XmlAttribute("number")]
		public int Number { get; set; }

		[XmlAttribute("name")]
		public string Name { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}