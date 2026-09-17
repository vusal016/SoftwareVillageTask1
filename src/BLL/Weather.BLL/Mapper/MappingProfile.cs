namespace Weather.BLL.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<CurrentWeather, CurrentWeatherDto>();
            CreateMap<DailyForecast, DailyForecastDto>();
            CreateMap<HourlyData, HourlyDataDto>();
        }
    }
}