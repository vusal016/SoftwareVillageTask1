namespace Weather.DAL.Repository
{
    public class WeatherRepository(WeatherDB weatherDB) : IWeatherRepository
    {
        public async Task<City?> GetCityWithWeatherDataAsync(string cityName)
        {
            return await weatherDB.Cities
                .Include(c => c.CurrentWeathers.OrderByDescending(cw => cw.RecordedAt).Take(1))
                .Include(c => c.DailyForecasts.OrderBy(d => d.ForecastDate))
                .Include(c => c.HourlyData.OrderBy(h => h.HourLabel))
                .FirstOrDefaultAsync(c => c.Name.ToLower() == cityName.ToLower());
        }
    }
}