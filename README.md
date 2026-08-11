# Weather API

## Project Overview

Weather API is an ASP.NET Core 9 RESTful API developed for a weather dashboard UI.

The API accepts a city name as a query parameter and returns all required weather dashboard data in a single response. The response contains city information, current weather conditions, daily forecasts, and hourly weather data.

The project follows Clean Architecture principles and a layered architecture approach.

## Technologies

- C# 13
- .NET 9
- ASP.NET Core 9
- Entity Framework Core 9
- SQL Server
- Swagger / OpenAPI
- AutoMapper
- Repository Pattern
- Dependency Injection

## Installation

### 1. Clone the Repository

```bash
git clone https://github.com/vusal016/SoftwareVillageTask1.git
cd SoftwareVillageTask1
```

### 2. Configure Environment Variables

Create a `.env` file in the project root directory.

Required environment variable:

```text
DefaultConnection
```

### 3. Set Up the Database

Make sure SQL Server or SQL Server LocalDB is running.

Apply the existing Entity Framework Core migrations:

```bash
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

The application can also be started using Visual Studio.

## Environment Variables

The following key is required in the `.env` file:

```text
DefaultConnection
```

Sensitive connection strings and credentials must not be committed to the Git repository.

## Database Setup

The project uses SQL Server with Entity Framework Core.

The main entities are:

* City
* CurrentWeather
* DailyForecast
* HourlyData

Entity relationships:

```text
City
 ├── CurrentWeather
 ├── DailyForecast
 └── HourlyData
```

To create the database and apply existing migrations:

```bash
dotnet ef database update
```

The project also contains a data seeding mechanism for initial test data.

## API Endpoints

### Get Weather by City

Returns complete weather dashboard data for the specified city.

**Method:**

```http
GET
```

**Endpoint:**

```text
/api/Weather
```

**Query Parameter:**

| Parameter | Type   | Required | Example |
| --------- | ------ | -------- | ------- |
| `city`    | string | Yes      | `Baku`  |

### Request

```http
GET /api/Weather?city=Baku
```

### Response — 200 OK

```json
{
  "data": {
    "city": {
      "name": "Baku",
      "countryCode": "AZ",
      "countryName": "Azerbaijan"
    },
    "currentWeather": {
      "temperature": 28.5,
      "feelsLike": 30.2,
      "windSpeed": 4.8,
      "windDirection": "NW",
      "pressure": 1012,
      "humidity": 58,
      "uvIndex": 6.5,
      "visibilityKm": 10,
      "visibilityCondition": "Clear",
      "dewPoint": 18.4,
      "sunriseTime": "05:42:00",
      "sunsetTime": "20:12:00",
      "weatherDescription": "Partly cloudy",
      "weatherIcon": "partly-cloudy",
      "recordedAt": "2026-08-10T16:30:00"
    },
    "dailyForecasts": [
      {
        "dayName": "Monday",
        "temperature": 29.5,
        "weatherDescription": "Sunny",
        "weatherIcon": "sunny",
        "forecastDate": "2026-08-10"
      },
      {
        "dayName": "Tuesday",
        "temperature": 31,
        "weatherDescription": "Partly cloudy",
        "weatherIcon": "partly-cloudy",
        "forecastDate": "2026-08-11"
      }
    ],
    "hourlyDatas": [
      {
        "hourLabel": "18:00",
        "windSpeed": 5.2,
        "rainProbability": 10,
        "rainCondition": "Low",
        "recordedAt": "2026-08-10T18:00:00"
      },
      {
        "hourLabel": "19:00",
        "windSpeed": 4.6,
        "rainProbability": 15,
        "rainCondition": "Low",
        "recordedAt": "2026-08-10T19:00:00"
      }
    ]
  },
  "isSuccess": true,
  "statusCode": 200,
  "errors": []
}
```

### Response — 400 Bad Request

Returned when the `city` parameter is empty or contains only whitespace.

```json
{
  "data": null,
  "isSuccess": false,
  "statusCode": 400,
  "errors": [
    "City name cannot be empty."
  ]
}
```

### Response — 404 Not Found

Returned when the requested city does not exist in the database.

```json
{
  "data": null,
  "isSuccess": false,
  "statusCode": 404,
  "errors": [
    "City was not found."
  ]
}
```

## Swagger

The API is documented using Swagger / OpenAPI.

Swagger UI:

```text
https://localhost:<PORT>/docs
```

Swagger provides:

* Endpoint description
* `city` query parameter name
* Parameter type
* Required parameter information
* `Baku` example value
* Complete 200 OK response example
* 400 Bad Request response example
* 404 Not Found response example

## Project Structure

```text
Weather.Task
│
├── .env
├── .gitignore
├── README.md
│
└── src
    ├── BLL
    ├── CORE
    ├── DAL
    └── PRESENTATION
```

### Layers

* **BLL** — business logic, services, DTOs, and mapping
* **CORE** — domain entities and validation
* **DAL** — Entity Framework Core, DbContext, repositories, and database operations
* **PRESENTATION** — API controllers, Swagger, middleware, and application configuration

## Author

**Vusal Mammadov**

* GitHub: [https://github.com/vusal016/SoftwareVillageTask1](https://github.com/vusal016/SoftwareVillageTask1)
* LinkedIn: [https://www.linkedin.com/in/vusalmemmedov/](https://www.linkedin.com/in/vusalmemmedov/)

---

This project was developed as part of the Software Village Internship Program.