namespace Weather.CORE.Entities
{
    public class CurrentWeather : BaseEntity
    {
        public CurrentWeather()
        {

        }
        public CurrentWeather(decimal temperature, decimal feelsLike, decimal windSpeed, string windDirection, int pressure, int humidity, decimal uvIndex, decimal visibilityKm, string visibilityCondition, decimal dewPoint, TimeOnly sunriseTime, TimeOnly sunsetTime, string weatherDescription, string weatherIcon, DateTime recordedAt, Guid cityId)
        {
            SetTemperature(temperature);
            SetFeelsLike(feelsLike);
            SetWindSpeed(windSpeed);
            SetWindDirection(windDirection);
            SetPressure(pressure);
            SetHumidity(humidity);
            SetUvIndex(uvIndex);
            SetVisibilityKm(visibilityKm);
            SetVisibilityCondition(visibilityCondition);
            SetDewPoint(dewPoint);
            SunriseTime = sunriseTime;
            SunsetTime = sunsetTime;
            SetWeatherDescription(weatherDescription);
            SetWeatherIcon(weatherIcon);
            SetRecordedAt(recordedAt);
            SetCityId(cityId);
        }

        public decimal Temperature { get; private set; }
        public decimal FeelsLike { get; private set; }
        public decimal WindSpeed { get; private set; }
        public string WindDirection { get; private set; }
        public int Pressure { get; private set; }
        public int Humidity { get; private set; }
        public decimal UvIndex { get; private set; }
        public decimal VisibilityKm { get; private set; }
        public string VisibilityCondition { get; private set; }
        public decimal DewPoint { get; private set; }
        public TimeOnly SunriseTime { get; private set; }
        public TimeOnly SunsetTime { get; private set; }
        public string WeatherDescription { get; private set; }
        public string WeatherIcon { get; private set; }
        public DateTime RecordedAt { get; private set; }
        public Guid CityId { get; private set; }
        public City City { get; private set; }

        private void SetTemperature(decimal temperature)
        {
            if (temperature < -100 || temperature > 100)
                throw new ArgumentOutOfRangeException(nameof(temperature), "Temperature must be between -100 and 100 degrees Celsius.");
            Temperature = temperature;
        }
        private void SetFeelsLike(decimal feelsLike)
        {
            if (feelsLike < -100 || feelsLike > 100)
                throw new ArgumentOutOfRangeException(nameof(feelsLike), "Feels like temperature must be between -100 and 100 degrees Celsius.");
            FeelsLike = feelsLike;
        }
        private void SetWindSpeed(decimal windSpeed)
        {
            if (windSpeed < 0)
                throw new ArgumentOutOfRangeException(nameof(windSpeed), "Wind speed cannot be negative.");
            WindSpeed = windSpeed;
        }
        private void SetWindDirection(string windDirection)
        {
            if (string.IsNullOrWhiteSpace(windDirection))
                throw new ArgumentException("Wind direction cannot be null or empty.", nameof(windDirection));
            WindDirection = windDirection;
        }
        private void SetPressure(int pressure)
        {
            if (pressure < 0)
                throw new ArgumentOutOfRangeException(nameof(pressure), "Pressure cannot be negative.");
            Pressure = pressure;
        }
        private void SetHumidity(int humidity)
        {
            if (humidity < 0 || humidity > 100)
                throw new ArgumentOutOfRangeException(nameof(humidity), "Humidity must be between 0 and 100 percent.");
            Humidity = humidity;
        }
        private void SetUvIndex(decimal uvIndex)
        {
            if (uvIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(uvIndex), "UV index cannot be negative.");
            UvIndex = uvIndex;
        }
        private void SetVisibilityKm(decimal visibilityKm)
        {
            if (visibilityKm < 0)
                throw new ArgumentOutOfRangeException(nameof(visibilityKm), "Visibility cannot be negative.");
            VisibilityKm = visibilityKm;
        }
        private void SetVisibilityCondition(string visibilityCondition)
        {
            if (string.IsNullOrWhiteSpace(visibilityCondition))
                throw new ArgumentException("Visibility condition cannot be null or empty.", nameof(visibilityCondition));
            VisibilityCondition = visibilityCondition;
        }
        private void SetDewPoint(decimal dewPoint)
        {
            if (dewPoint < -100 || dewPoint > 100)
                throw new ArgumentOutOfRangeException(nameof(dewPoint), "Dew point must be between -100 and 100 degrees Celsius.");
            DewPoint = dewPoint;
        }
        private void SetWeatherDescription(string weatherDescription)
        {
            if (string.IsNullOrWhiteSpace(weatherDescription))
                throw new ArgumentException("Weather description cannot be null or empty.", nameof(weatherDescription));
            WeatherDescription = weatherDescription;
        }
        private void SetWeatherIcon(string weatherIcon)
        {
            if (string.IsNullOrWhiteSpace(weatherIcon))
                throw new ArgumentException("Weather icon cannot be null or empty.", nameof(weatherIcon));
            WeatherIcon = weatherIcon;
        }
        private void SetRecordedAt(DateTime recordedAt)
        {
            if (recordedAt > DateTime.UtcNow)
                throw new ArgumentOutOfRangeException(nameof(recordedAt), "Recorded time cannot be in the future.");
            RecordedAt = recordedAt;
        }
        private void SetCityId(Guid cityId)
        {
            if (cityId == Guid.Empty)
                throw new ArgumentException("City ID cannot be empty.", nameof(cityId));
            CityId = cityId;
        }
    }
}
