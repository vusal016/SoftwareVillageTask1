namespace Weather.DAL.Configurations
{
    public class DailyForecastConfigurations : IEntityTypeConfiguration<DailyForecast>
    {
        public void Configure(EntityTypeBuilder<DailyForecast> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DayName)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Temperature)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(x => x.WeatherDescription)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.WeatherIcon)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.ForecastDate)
                .IsRequired();

            builder.Property(x => x.CityId)
                .IsRequired();

            builder.HasOne(x => x.City)
                .WithMany(x => x.DailyForecasts)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}