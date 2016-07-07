using System.Threading.Tasks;
using Refit;
using WeatherForecast.Logic.Entity.Picture;
using WeatherForecast.Logic.Service;

namespace WeatherForecast.Logic.ServiceImpl
{
	public class PhotoService : IPhotoService
	{
		public const string FlickrServer = "https://api.flickr.com/services/";

		private readonly IPhotoServiceInternal _photoServiceInternal;

		public PhotoService()
		{
			_photoServiceInternal = RestService.For<IPhotoServiceInternal>(FlickrServer);
		}

		public PhotoService(IPhotoServiceInternal photoServiceInternal)
		{
			_photoServiceInternal = photoServiceInternal;
		}

		public async Task<FlickrData> GetFlickUrlPhoto(string city)
		{
			var data = await _photoServiceInternal.GetFlickUrlPhoto(city);
			var flickData = data.Parse<FlickrData>();
			return flickData;
		}
	}
}