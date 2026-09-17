namespace Weather.BLL.Dtos
{
    public record DailyForecastDto(string DayName, decimal Temperature, string WeatherDescription, string WeatherIcon, DateOnly ForecastDate);
}
