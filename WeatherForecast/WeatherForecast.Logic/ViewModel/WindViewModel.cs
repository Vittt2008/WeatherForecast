using WeatherForecast.Logic.Converter;

namespace WeatherForecast.Logic.ViewModel
{
	public class WindViewModel
	{
		private string _name;

		public string Name
		{
			get { return WeatherFormatter.Capitalize(_name); }
			set { _name = value; }
		}

		public float Value { get; set; }
		public string DirectionName { get; set; }
		public float DirectionValue { get; set; }
		public Unit Unit { get; set; }
		public string WindValue => Unit == Unit.Metric ? WeatherFormatter.WindShortInformationMetrePerSecond(this) : WeatherFormatter.WindShortInformationMilesPerHour(this);
		public override string ToString()
		{
			return Unit == Unit.Metric ? WeatherFormatter.WindInformationMetrePerSecond(this) : WeatherFormatter.WindInformationMilesPerHour(this);
		}

	}
}