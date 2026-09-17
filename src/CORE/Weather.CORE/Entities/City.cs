namespace Weather.CORE.Entities
{
    public class City : BaseEntity
    {
        public City()
        {

        }
        public City(string name, string countryCode, string countryName)
        {
            SetName(name);
            SetCountryCode(countryCode);
            SetCountryName(countryName);
        }
        public string Name { get; private set; }
        public string CountryCode { get; private set; }
        public string CountryName { get; private set; }
        public ICollection<CurrentWeather> CurrentWeathers { get; private set; } = new List<CurrentWeather>();
        public ICollection<DailyForecast> DailyForecasts { get; private set; } = new List<DailyForecast>();
        public ICollection<HourlyData> HourlyData { get; private set; } = new List<HourlyData>();

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("City name cannot be null or empty.");
            Name = name;
        }
        private void SetCountryCode(string countryCode)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
                throw new ArgumentException("Country code cannot be null or empty.");
            CountryCode = countryCode;
        }
        private void SetCountryName(string countryName)
        {
            if (string.IsNullOrWhiteSpace(countryName))
                throw new ArgumentException("Country name cannot be null or empty.");
            CountryName = countryName;
        }
    }
}
