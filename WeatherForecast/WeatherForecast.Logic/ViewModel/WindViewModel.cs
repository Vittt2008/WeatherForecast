using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherForecast.Logic.Annotations;
using WeatherForecast.Logic.Converter;

namespace WeatherForecast.Logic.ViewModel
{
	public class WindViewModel : BaseViewModel
	{
		private Unit _unit;

		public string Name { get; }
		public float Value { get; }
		public string DirectionName { get; }
		public float DirectionValue { get; }
		public string ShortInfo=> Unit == Unit.Metric ? WeatherFormatter.WindShortInfoMps(this) : WeatherFormatter.WindShortInfoMph(this);
		public string FullInfo => Unit == Unit.Metric ? WeatherFormatter.WindFullInfoMps(this) : WeatherFormatter.WindFullInfoMph(this);

		public Unit Unit
		{
			get { return _unit; }
			set
			{
				if (_unit == value)
					return;

				_unit = value;
				OnPropertyChanged(nameof(Unit));
				OnPropertyChanged(nameof(ShortInfo));
				OnPropertyChanged(nameof(FullInfo));
			}
		}

		public WindViewModel(string name, float value, string directionName, float directionValue)
		{
			Name = WeatherFormatter.Capitalize(name);
			Value = value;
			DirectionName = directionName;
			DirectionValue = directionValue;
		}
	}
}