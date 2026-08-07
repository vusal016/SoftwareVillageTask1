namespace Weather.DAL.Configurations
{
    public class CityConfigurations : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.CountryCode)
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(x => x.CountryName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}