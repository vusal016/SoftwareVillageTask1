namespace Weather.CORE.Entities
{
    public class HourlyData:BaseEntity
    {
        public HourlyData()
        {
            
        }
        public HourlyData(string hourLabel, decimal windSpeed, int rainProbability, string rainCondition, DateTime recordedAt, Guid cityId)
        {
            SetHourLabel(hourLabel);
            SetWindSpeed(windSpeed);
            SetRainProbability(rainProbability);
            SetRainCondition(rainCondition);
            RecordedAt = recordedAt;
            CityId = cityId;
        }

        public string HourLabel {get; set;}
        public decimal WindSpeed {get; set;}
        public int RainProbability {get; set;}
        public string RainCondition {get; set; }
        public DateTime RecordedAt {get; set;}
        public Guid CityId { get; set; }
        public City City {get; set;}

        private void SetHourLabel(string hourLabel)
        {
            if (string.IsNullOrWhiteSpace(hourLabel))
                throw new ArgumentException("Hour label cannot be null or empty.");
            HourLabel = hourLabel;
        }
        private void SetWindSpeed(decimal windSpeed)
        {
            if (windSpeed < 0)
                throw new ArgumentOutOfRangeException(nameof(windSpeed), "Wind speed cannot be negative.");
            WindSpeed = windSpeed;
        }   
        private void SetRainProbability(int rainProbability)
        {
            if (rainProbability < 0 || rainProbability > 100)
                throw new ArgumentOutOfRangeException(nameof(rainProbability), "Rain probability must be between 0 and 100 percent.");
            RainProbability = rainProbability;
        }
        private void SetRainCondition(string rainCondition)
        {
            if (string.IsNullOrWhiteSpace(rainCondition))
                throw new ArgumentException("Rain condition cannot be null or empty.");
            RainCondition = rainCondition;
        }   
         
    }
}
