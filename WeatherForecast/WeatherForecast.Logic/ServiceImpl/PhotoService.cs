using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
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

		public async Task<BitmapImage> GetImageFromUrl(string url)
		{
			var request = WebRequest.Create(url);
			using (var response = await request.GetResponseAsync())
			using (var stream = response.GetResponseStream())
			using (var memoryStream = new MemoryStream())
			{
				await stream.CopyToAsync(memoryStream);
				memoryStream.Position = 0;
				var bitmap = new BitmapImage();
				await bitmap.SetSourceAsync(memoryStream.AsRandomAccessStream());
				return bitmap;
			}
		}
	}
}