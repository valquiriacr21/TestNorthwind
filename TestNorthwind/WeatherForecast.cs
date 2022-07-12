using System;
using System.ComponentModel.DataAnnotations;

namespace TestNorthwind
{
    public class WeatherForecast
    {
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
