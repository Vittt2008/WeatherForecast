namespace WeatherForecast.Logic.Entity.Forecast.Virtual
{
	public class DailyTemperature
	{
		public string Unit { get; set; }
		public float Day { get; set; }
		public float Min { get; set; }
		public float Max { get; set; }
		public float Night { get; set; }
		public float Eve { get; set; }
		public float Morn { get; set; }

		public DailyTemperature()
		{
		}

		public DailyTemperature(string unit, float day, float min, float max, float night, float eve, float morn)
		{
			Unit = unit;
			Day = day;
			Min = min;
			Max = max;
			Night = night;
			Eve = eve;
			Morn = morn;
		}
	}
}