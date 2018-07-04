using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class WeatherForecast
    {
        public city city { get; set; }
        public List<list> list { get; set; }  //forecast list
    }

    public class temp
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
    }
    public class weather
    {
        public string main { get; set; } //weather condition
        public string description { get; set; } //weather description
        public string icon { get; set; }
    }

    public class city
    {
        public string name { get; set; }
    }
    public class list
    {
        public double dt { get; set; }  //day in millisecond
        public double pressure { get; set; }  //pressure hpa
        public double humidity { get; set; }  //humidity %
        public double speed { get; set; }  //wind speed m/h
        public temp temp { get; set; }
        public List<weather> weather { get; set; } //weather list
    }
}
