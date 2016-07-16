using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using WeatherForecast.Logic.Entity.Picture;

namespace WeatherForecast.Logic.Service
{
	public interface IPhotoService
	{
		Task<FlickrData> GetFlickUrlPhotoAsync(string city);
		Task<BitmapImage> GetImageFromUrlAsync(string url);
	}
}