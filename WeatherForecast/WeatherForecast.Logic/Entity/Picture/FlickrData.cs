using System.Collections.Generic;
using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Picture
{
	[XmlRoot("rsp")]
	public class FlickrData
	{
		[XmlArray("photos")]
		public List<Photo> photos { get; set; }
	}
}