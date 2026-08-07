namespace Weather.DAL.Data
{
    public class WeatherDB(DbContextOptions<WeatherDB> options):DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<CurrentWeather> CurrentWeathers { get; set; }
        public DbSet<DailyForecast> DailyForecasts { get; set; }
        public DbSet<HourlyData> HourlyData { get; set; }    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(WeatherDB).Assembly);
        }
    }
}