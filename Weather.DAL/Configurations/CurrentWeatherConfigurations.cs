namespace Weather.DAL.Configurations
{
    public class CurrentWeatherConfigurations : IEntityTypeConfiguration<CurrentWeather>
    {
        public void Configure(EntityTypeBuilder<CurrentWeather> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Temperature)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(x => x.FeelsLike)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(x => x.WindSpeed)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(x => x.WindDirection)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Pressure)
                .IsRequired();

            builder.Property(x => x.Humidity)
                .IsRequired();

            builder.Property(x => x.UvIndex)
                .HasPrecision(4, 2)
                .IsRequired();

            builder.Property(x => x.VisibilityKm)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(x => x.VisibilityCondition)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.DewPoint)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(x => x.SunriseTime)
                .IsRequired();

            builder.Property(x => x.SunsetTime)
                .IsRequired();

            builder.Property(x => x.WeatherDescription)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.WeatherIcon)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.RecordedAt)
                .IsRequired();

            builder.Property(x => x.CityId)
                .IsRequired();

            builder.HasOne(x => x.City)
                .WithMany(x => x.CurrentWeathers)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}