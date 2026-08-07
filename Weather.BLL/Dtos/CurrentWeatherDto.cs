namespace Weather.BLL.Dtos
{
    public record CurrentWeatherDto(decimal Temperature, decimal FeelsLike, decimal WindSpeed, string WindDirection, int Pressure, int Humidity, decimal UvIndex, decimal VisibilityKm, string VisibilityCondition, decimal DewPoint, TimeOnly SunriseTime, TimeOnly SunsetTime, string WeatherDescription, string WeatherIcon, DateTime RecordedAt);
}
