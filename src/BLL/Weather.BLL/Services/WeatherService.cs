namespace Weather.BLL.Services
{
    public class WeatherService(IWeatherRepository repository, IMapper mapper) : IWeatherService
    {
        public async Task<WeatherResponseDto> GetWeatherByCityAsync(string cityName)
        {
            var city = await repository.GetCityWithWeatherDataAsync(cityName)
               ?? throw new NotExistException($"'{cityName}' This city does not exist.");

            var dto = new WeatherResponseDto(
                mapper.Map<CityDto>(city),
                mapper.Map<CurrentWeatherDto>(city.CurrentWeathers.FirstOrDefault()),
                mapper.Map<List<DailyForecastDto>>(city.DailyForecasts),
                mapper.Map<List<HourlyDataDto>>(city.HourlyData)
            );

            return dto;
        }
    }
}