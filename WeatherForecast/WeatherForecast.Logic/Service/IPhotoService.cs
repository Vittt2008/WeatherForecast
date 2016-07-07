using System.Threading.Tasks;
using WeatherForecast.Logic.Entity.Picture;

namespace WeatherForecast.Logic.Service
{
	public interface IPhotoService
	{
		Task<FlickrData> GetFlickUrlPhoto(string city);
	}
}