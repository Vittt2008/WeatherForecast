using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Forecast
{
	/// <summary>
	/// Местоположение
	/// </summary>
	[XmlRoot("location")]
	public class Location
	{
		[XmlElement("name")]
		public string City { get; set; }

		[XmlElement("country")]
		public string Country { get; set; }

		public override string ToString()
		{
			return $"{City}, {Country}";
		}
	}
}