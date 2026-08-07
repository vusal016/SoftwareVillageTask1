using Weather.CORE.Entities;

namespace Weather.CORE.Repository
{
    public interface IWeatherRepository
    {
        Task<City> GetCityWithWeatherDataAsync(string cityName);
    }
}