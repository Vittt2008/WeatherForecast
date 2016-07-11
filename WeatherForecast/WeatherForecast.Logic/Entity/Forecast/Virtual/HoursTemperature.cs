namespace WeatherForecast.Logic.Entity.Forecast.Virtual
{
	public class HoursTemperature
	{
		public string Unit { get; set; }
		public float Value { get; set; }
		public float Min { get; set; }
		public float Max { get; set; }

		public HoursTemperature()
		{
		}

		public HoursTemperature(string unit, float value, float min, float max)
		{
			Unit = unit;
			Value = value;
			Min = min;
			Max = max;
		}
	}
}