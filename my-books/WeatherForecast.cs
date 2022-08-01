using System;

namespace my_books
{
    // Takođe imamo testnu klasu koju će mo kasnije izbrisati, jer nam nije potrebna za ovaj projekat
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
