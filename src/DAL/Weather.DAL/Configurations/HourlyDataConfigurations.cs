
namespace Weather.DAL.Configurations
{
    public class HourlyDataConfigurations : IEntityTypeConfiguration<HourlyData>
    {
        public void Configure(EntityTypeBuilder<HourlyData> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.HourLabel)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.WindSpeed)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(x => x.RainProbability)
                .IsRequired();

            builder.Property(x => x.RainCondition)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.RecordedAt)
                .IsRequired();

            builder.Property(x => x.CityId)
                .IsRequired();

            builder.HasOne(x => x.City)
                .WithMany(x => x.HourlyData)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
