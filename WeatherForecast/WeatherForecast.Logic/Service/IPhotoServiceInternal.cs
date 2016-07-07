using System;
using System.Threading.Tasks;
using Refit;
using WeatherForecast.Logic.Entity.Picture;

namespace WeatherForecast.Logic.Service
{
	public interface IPhotoServiceInternal
	{
		[Get("/rest?method=flickr.photos.search&api_key=e0aeeba90ac23c595de87d3459f64ecc&sort=relevance&per_page=20&format=rest")]
		Task<string> GetFlickUrlPhoto([AliasAs("text")] string city);
	}
}