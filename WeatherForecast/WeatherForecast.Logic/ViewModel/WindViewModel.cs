using WeatherForecast.Logic.Converter.Speed;

namespace WeatherForecast.Logic.ViewModel
{
	public class WindViewModel
	{
		public string Name { get; set; }
		public float Value { get; set; }
		public string DirectionName { get; set; }
		public float DirectionValue { get; set; }
		public Unit Unit { get; set; }
		public string WindValue => Unit == Unit.Metric ? MetresPerSecondConverter.ConvertWindValue(this) : MilesPerHourConverter.ConvertWindValue(this);
		public override string ToString()
		{
			return Unit == Unit.Metric ? MetresPerSecondConverter.ConvertWind(this) : MilesPerHourConverter.ConvertWind(this);
		}

	}
}