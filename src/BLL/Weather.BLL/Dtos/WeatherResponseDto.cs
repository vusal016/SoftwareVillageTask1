namespace Weather.BLL.Dtos
{
    public record WeatherResponseDto(CityDto City,CurrentWeatherDto CurrentWeather,List<DailyForecastDto>DailyForecasts,List<HourlyDataDto>HourlyDatas);
}
