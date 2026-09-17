namespace WeatherAPI.Swagger
{
    public class WeatherResponseExampleFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.Name != "GetWeatherDashboard")
                return;

            var cityParameter = operation.Parameters.FirstOrDefault(x => x.Name == "city");

            if (cityParameter is not null)
            {
                cityParameter.Required = true;
                cityParameter.Example = new OpenApiString("Baku");
            }

            if (operation.Responses.TryGetValue("200", out var successResponse))
            {
                successResponse.Description = "Weather data retrieved successfully.";
                successResponse.Content.Clear();

                successResponse.Content["application/json"] = new OpenApiMediaType
                {
                    Example = new OpenApiObject
                    {
                        ["data"] = new OpenApiObject
                        {
                            ["city"] = new OpenApiObject
                            {
                                ["name"] = new OpenApiString("Baku"),
                                ["countryCode"] = new OpenApiString("AZ"),
                                ["countryName"] = new OpenApiString("Azerbaijan")
                            },

                            ["currentWeather"] = new OpenApiObject
                            {
                                ["temperature"] = new OpenApiDouble(28.5),
                                ["feelsLike"] = new OpenApiDouble(30.2),
                                ["windSpeed"] = new OpenApiDouble(4.8),
                                ["windDirection"] = new OpenApiString("NW"),
                                ["pressure"] = new OpenApiInteger(1012),
                                ["humidity"] = new OpenApiInteger(58),
                                ["uvIndex"] = new OpenApiDouble(6.5),
                                ["visibilityKm"] = new OpenApiDouble(10),
                                ["visibilityCondition"] = new OpenApiString("Clear"),
                                ["dewPoint"] = new OpenApiDouble(18.4),
                                ["sunriseTime"] = new OpenApiString("05:42:00"),
                                ["sunsetTime"] = new OpenApiString("20:12:00"),
                                ["weatherDescription"] = new OpenApiString("Partly cloudy"),
                                ["weatherIcon"] = new OpenApiString("partly-cloudy"),
                                ["recordedAt"] = new OpenApiString("2026-08-10T16:30:00")
                            },

                            ["dailyForecasts"] = new OpenApiArray
                        {
                            new OpenApiObject
                            {
                                ["dayName"] = new OpenApiString("Monday"),
                                ["temperature"] = new OpenApiDouble(29.5),
                                ["weatherDescription"] = new OpenApiString("Sunny"),
                                ["weatherIcon"] = new OpenApiString("sunny"),
                                ["forecastDate"] = new OpenApiString("2026-08-10")
                            },
                            new OpenApiObject
                            {
                                ["dayName"] = new OpenApiString("Tuesday"),
                                ["temperature"] = new OpenApiDouble(31.0),
                                ["weatherDescription"] = new OpenApiString("Partly cloudy"),
                                ["weatherIcon"] = new OpenApiString("partly-cloudy"),
                                ["forecastDate"] = new OpenApiString("2026-08-11")
                            }
                        },

                            ["hourlyDatas"] = new OpenApiArray
                        {
                            new OpenApiObject
                            {
                                ["hourLabel"] = new OpenApiString("18:00"),
                                ["windSpeed"] = new OpenApiDouble(5.2),
                                ["rainProbability"] = new OpenApiInteger(10),
                                ["rainCondition"] = new OpenApiString("Low"),
                                ["recordedAt"] = new OpenApiString("2026-08-10T18:00:00")
                            },
                            new OpenApiObject
                            {
                                ["hourLabel"] = new OpenApiString("19:00"),
                                ["windSpeed"] = new OpenApiDouble(4.6),
                                ["rainProbability"] = new OpenApiInteger(15),
                                ["rainCondition"] = new OpenApiString("Low"),
                                ["recordedAt"] = new OpenApiString("2026-08-10T19:00:00")
                            }
                        }
                        },

                        ["isSuccess"] = new OpenApiBoolean(true),
                        ["statusCode"] = new OpenApiInteger(200),
                        ["errors"] = new OpenApiArray()
                    }
                };
            }

            if (operation.Responses.TryGetValue("400", out var badRequestResponse))
            {
                badRequestResponse.Description = "City name cannot be empty.";
                badRequestResponse.Content.Clear();

                badRequestResponse.Content["application/json"] = new OpenApiMediaType
                {
                    Example = new OpenApiObject
                    {
                        ["data"] = new OpenApiNull(),
                        ["isSuccess"] = new OpenApiBoolean(false),
                        ["statusCode"] = new OpenApiInteger(400),
                        ["errors"] = new OpenApiArray
                    {
                        new OpenApiString("City name cannot be empty.")
                    }
                    }
                };
            }

            if (operation.Responses.TryGetValue("404", out var notFoundResponse))
            {
                notFoundResponse.Description = "City was not found.";
                notFoundResponse.Content.Clear();

                notFoundResponse.Content["application/json"] = new OpenApiMediaType
                {
                    Example = new OpenApiObject
                    {
                        ["data"] = new OpenApiNull(),
                        ["isSuccess"] = new OpenApiBoolean(false),
                        ["statusCode"] = new OpenApiInteger(404),
                        ["errors"] = new OpenApiArray
                    {
                        new OpenApiString("City was not found.")
                    }
                    }
                };
            }
        }
    }
}