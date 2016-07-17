using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WeatherForecast.Logic.Entity.Picture
{
	[XmlRoot("rsp")]
	public class FlickrData
	{
		private static readonly Random Random = new Random();

		[XmlArray("photos")]
		[XmlArrayItem("photo")]
		public List<Photo> Photos { get; set; }

		public string RandomPhotoUrl => Photos.Count == 0 ? string.Empty : Photos[Random.Next(Photos.Count)].PhotoUrl;
	}
}