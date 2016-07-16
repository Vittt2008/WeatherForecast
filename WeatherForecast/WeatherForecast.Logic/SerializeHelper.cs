using System.IO;
using System.Xml.Serialization;

namespace WeatherForecast.Logic
{
	public static class SerializeHelper
	{
		public static string Serialize<T>(this T data)
		{
			var serializer = new XmlSerializer(typeof(T));
			using (var stringWriter = new StringWriter())
			{
				serializer.Serialize(stringWriter, data);
				return stringWriter.ToString();
			}
		}

		public static T DeserializeTo<T>(this string xml)
		{
			var serializer = new XmlSerializer(typeof(T));
			using (var stringReader = new StringReader(xml))
			{
				var data = (T)serializer.Deserialize(stringReader);
				return data;
			}
		}
	}
}