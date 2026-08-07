namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController(IWeatherService weatherService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetWeatherDashboard(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return BadRequest(Response<string>.Fail("City name cannot be empty.", 400));

            var result = await weatherService.GetWeatherByCityAsync(city);
            return Ok(Response<WeatherResponseDto>.Success(result, 200));

        }
    }
}


