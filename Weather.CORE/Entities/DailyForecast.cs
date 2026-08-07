namespace Weather.CORE.Entities
{
    public class DailyForecast:BaseEntity
    {
        public DailyForecast()
        {
            
        }
        public DailyForecast(string dayName, decimal temperature, string weatherDescription, string weatherIcon, DateOnly forecastDate, Guid cityId)
        {
            SetDayName(dayName);
            SetTemperature(temperature);
            SetWeatherDescription(weatherDescription);
            SetWeatherIcon(weatherIcon);
            ForecastDate = forecastDate;
            CityId = cityId;
        }

        public string DayName {get;private set;}
        public decimal Temperature {get;private set;}
        public string WeatherDescription {get;private set;}
        public string WeatherIcon {get;private set;}
        public DateOnly ForecastDate {get;private set;}
        public Guid CityId {get;private set;}
        public City City {get; private set;}

        private void SetDayName(string dayName)
        {
            if (string.IsNullOrWhiteSpace(dayName))
                throw new ArgumentException("Day name cannot be null or empty.");
            DayName = dayName;
        }
        private void SetTemperature(decimal temperature)
        {
            if (temperature < -100 || temperature > 100)
                throw new ArgumentOutOfRangeException(nameof(temperature), "Temperature must be between -100 and 100 degrees Celsius.");
            Temperature = temperature;
        }
        private void SetWeatherDescription(string weatherDescription)
        {
            if (string.IsNullOrWhiteSpace(weatherDescription))
                throw new ArgumentException("Weather description cannot be null or empty.");
            WeatherDescription = weatherDescription;
        }
        private void SetWeatherIcon(string weatherIcon)
        {
            if (string.IsNullOrWhiteSpace(weatherIcon))
                throw new ArgumentException("Weather icon cannot be null or empty.");
            WeatherIcon = weatherIcon;
        }
    }
}
