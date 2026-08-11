namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    ///<summary>
    /// Controller for managing weather-related endpoints.
    ///</summary>
    public class WeatherController(IWeatherService weatherService) : ControllerBase
    {  /// <summary>
       /// Retrieves complete weather dashboard data for the specified city.
       /// </summary>  
       /// <param name="city">City name. Example: Baku.</param>
       /// <response code="200">Weather data retrieved successfully.</response>
       /// <response code="400">City name cannot be empty.</response>
       /// <response code="404">City was not found.</response>
        [ProducesResponseType(typeof(Response<WeatherResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<object>), StatusCodes.Status404NotFound)]
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetWeatherDashboard(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return BadRequest(Response<string>.Fail("City name cannot be empty.", 400));

            var result = await weatherService.GetWeatherByCityAsync(city);
            return Ok(Response<WeatherResponseDto>.Success(result, 200));

        }
    }
}