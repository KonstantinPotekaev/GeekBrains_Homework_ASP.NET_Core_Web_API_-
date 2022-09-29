using System.Security.Cryptography.X509Certificates;

namespace WeatherForeCast.Models
{
    /// <summary>
    /// Прогноз погоды Forecats  
    /// </summary>
    public class WeatherForeCast
    {
        /// <summary>
        /// Дата измерения
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Температура в градусах Цельсия
        /// </summary>
        public double TemperatureC { get; set; }

        /// <summary>
        /// Температура по Форенгейту 
        /// </summary>
        public double TemperatureF => 32 + TemperatureC / 0.5556;

        public string Summary => TemperatureC switch
        {
            <= -30 => "Freezing",
            <= -20 => "Bracing",
            <= -10 => "Chilly",
            <= 5 => "Cold",
            <= 10 => "Mild",
            <= 20 => "Warm",
            <= 30 => "Blamy",
            <= 35 => "Hot",
            _ => "No case available"
        };

    }
}
