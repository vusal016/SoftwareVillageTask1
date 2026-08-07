using Microsoft.EntityFrameworkCore;

namespace Weather.DAL.Data.Seed
{
    public class DataSeeder(WeatherDB weatherDB)
    {
        public async Task Initialize()
        {
            await weatherDB.Database.MigrateAsync();

            await SeedCities();
            await SeedCurrentWeathers();
            await SeedDailyForecasts();
            await SeedHourlyData();
        }
        private async Task SeedCities()
        {
            if (await weatherDB.Cities.AnyAsync())
                return;

            var cities = new List<City>
            {
                new City("Dhaka", "BD", "Bangladesh"),
                new City("Baku", "AZ", "Azerbaijan")
            };

            await weatherDB.Cities.AddRangeAsync(cities);
            await weatherDB.SaveChangesAsync();
        }

        private async Task SeedCurrentWeathers()
        {
            if (await weatherDB.CurrentWeathers.AnyAsync())
                return;

            var dhaka = await weatherDB.Cities
                .FirstAsync(c => c.Name == "Dhaka");

            var baku = await weatherDB.Cities
                .FirstAsync(c => c.Name == "Baku");

            var currentWeathers = new List<CurrentWeather>
            {
                new CurrentWeather(
                    31.5m,
                    35.2m,
                    14.5m,
                    "SW",
                    1005,
                    78,
                    8.2m,
                    7.5m,
                    "Moderate",
                    26.1m,
                    new TimeOnly(5, 25),
                    new TimeOnly(18, 35),
                    "Partly cloudy",
                    "partly-cloudy",
                    DateTime.UtcNow.AddMinutes(-10),
                    dhaka.Id
                ),

                new CurrentWeather(
                    29.3m,
                    30.1m,
                    18.2m,
                    "N",
                    1012,
                    52,
                    7.4m,
                    10.0m,
                    "Clear",
                    18.4m,
                    new TimeOnly(5, 35),
                    new TimeOnly(20, 15),
                    "Clear sky",
                    "clear",
                    DateTime.UtcNow.AddMinutes(-10),
                    baku.Id
                )
            };

            await weatherDB.CurrentWeathers.AddRangeAsync(currentWeathers);
            await weatherDB.SaveChangesAsync();
        }

        private async Task SeedDailyForecasts()
        {
            if (await weatherDB.DailyForecasts.AnyAsync())
                return;

            var dhaka = await weatherDB.Cities
                .FirstAsync(c => c.Name == "Dhaka");

            var baku = await weatherDB.Cities
                .FirstAsync(c => c.Name == "Baku");

            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var dailyForecasts = new List<DailyForecast>
            {
                new DailyForecast(
                    "Friday",
                    32.0m,
                    "Partly cloudy",
                    "partly-cloudy",
                    today,
                    dhaka.Id
                ),

                new DailyForecast(
                    "Saturday",
                    33.0m,
                    "Sunny",
                    "sunny",
                    today.AddDays(1),
                    dhaka.Id
                ),

                new DailyForecast(
                    "Sunday",
                    31.0m,
                    "Light rain",
                    "rain",
                    today.AddDays(2),
                    dhaka.Id
                ),

                new DailyForecast(
                    "Monday",
                    30.0m,
                    "Thunderstorms",
                    "thunderstorm",
                    today.AddDays(3),
                    dhaka.Id
                ),

                new DailyForecast(
                    "Tuesday",
                    32.0m,
                    "Partly cloudy",
                    "partly-cloudy",
                    today.AddDays(4),
                    dhaka.Id
                ),

                new DailyForecast(
                    "Wednesday",
                    34.0m,
                    "Sunny",
                    "sunny",
                    today.AddDays(5),
                    dhaka.Id
                ),

                new DailyForecast(
                    "Friday",
                    30.0m,
                    "Clear sky",
                    "clear",
                    today,
                    baku.Id
                ),

                new DailyForecast(
                    "Saturday",
                    31.0m,
                    "Sunny",
                    "sunny",
                    today.AddDays(1),
                    baku.Id
                ),

                new DailyForecast(
                    "Sunday",
                    29.0m,
                    "Partly cloudy",
                    "partly-cloudy",
                    today.AddDays(2),
                    baku.Id
                ),

                new DailyForecast(
                    "Monday",
                    28.0m,
                    "Windy",
                    "windy",
                    today.AddDays(3),
                    baku.Id
                ),

                new DailyForecast(
                    "Tuesday",
                    30.0m,
                    "Sunny",
                    "sunny",
                    today.AddDays(4),
                    baku.Id
                ),

                new DailyForecast(
                    "Wednesday",
                    32.0m,
                    "Clear sky",
                    "clear",
                    today.AddDays(5),
                    baku.Id
                )
            };

            await weatherDB.DailyForecasts.AddRangeAsync(dailyForecasts);
            await weatherDB.SaveChangesAsync();
        }

        private async Task SeedHourlyData()
        {
            if (await weatherDB.HourlyData.AnyAsync())
                return;

            var dhaka = await weatherDB.Cities
                .FirstAsync(c => c.Name == "Dhaka");

            var baku = await weatherDB.Cities
                .FirstAsync(c => c.Name == "Baku");

            var recordedAt = DateTime.UtcNow;

            var hourlyData = new List<HourlyData>
            {
                new HourlyData(
                    "14:00",
                    12.0m,
                    20,
                    "Low",
                    recordedAt,
                    dhaka.Id
                ),

                new HourlyData(
                    "15:00",
                    14.0m,
                    25,
                    "Low",
                    recordedAt,
                    dhaka.Id
                ),

                new HourlyData(
                    "16:00",
                    15.0m,
                    35,
                    "Moderate",
                    recordedAt,
                    dhaka.Id
                ),

                new HourlyData(
                    "17:00",
                    16.0m,
                    45,
                    "Moderate",
                    recordedAt,
                    dhaka.Id
                ),

                new HourlyData(
                    "18:00",
                    13.0m,
                    55,
                    "High",
                    recordedAt,
                    dhaka.Id
                ),

                new HourlyData(
                    "19:00",
                    11.0m,
                    60,
                    "High",
                    recordedAt,
                    dhaka.Id
                ),

                new HourlyData(
                    "14:00",
                    17.0m,
                    5,
                    "Very low",
                    recordedAt,
                    baku.Id
                ),

                new HourlyData(
                    "15:00",
                    18.0m,
                    5,
                    "Very low",
                    recordedAt,
                    baku.Id
                ),

                new HourlyData(
                    "16:00",
                    20.0m,
                    10,
                    "Low",
                    recordedAt,
                    baku.Id
                ),

                new HourlyData(
                    "17:00",
                    19.0m,
                    10,
                    "Low",
                    recordedAt,
                    baku.Id
                ),

                new HourlyData(
                    "18:00",
                    21.0m,
                    5,
                    "Very low",
                    recordedAt,
                    baku.Id
                ),

                new HourlyData(
                    "19:00",
                    18.0m,
                    5,
                    "Very low",
                    recordedAt,
                    baku.Id
                )
            };

            await weatherDB.HourlyData.AddRangeAsync(hourlyData);
            await weatherDB.SaveChangesAsync();
        }
    }
}
