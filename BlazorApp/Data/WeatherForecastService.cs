using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastService> _log;
        private readonly IDataAccess _db;

        public WeatherForecastService(ILogger<WeatherForecastService> log, IDataAccess db)
        {
            _log = log;
            _db = db;
        }
        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            _log.LogInformation("Getting the forecast");
            _log.LogInformation("The random nuber is: {rando}", _db.GetUserAge());
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1,_db.GetUserAge()).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
