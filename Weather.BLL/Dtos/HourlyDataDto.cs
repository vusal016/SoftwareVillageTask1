namespace Weather.BLL.Dtos
{
    public record HourlyDataDto(string HourLabel, decimal WindSpeed, int RainProbability, string RainCondition,DateTime RecordedAt);
}
