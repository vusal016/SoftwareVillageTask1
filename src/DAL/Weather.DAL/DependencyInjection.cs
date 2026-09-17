namespace Weather.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WeatherDB>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IWeatherRepository, WeatherRepository>();
            services.AddScoped<DataSeeder>();
            return services;
        }
    }
}