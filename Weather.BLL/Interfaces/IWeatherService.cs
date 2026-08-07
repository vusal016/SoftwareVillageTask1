namespace Weather.BLL.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherResponseDto> GetWeatherByCityAsync(string cityName);

    }
}