using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WeatherApp
{
    public partial class frmWeatherApp : Form
    {
        const string APPID = "542ffd081e67f4512b705f89d2a611b2";

        public frmWeatherApp()
        {
            InitializeComponent();
            getWeather("Houston");  //one day weather
            getForecast("Houston"); //more than one day
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getWeather(txtSearchCity.Text); //one day weather
            getForecast(txtSearchCity.Text); //more than one day
            txtSearchCity.Clear();
            txtSearchCity.Focus();
        }

        // For Today's Weather info
        void getWeather(string city)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=imperial", city, APPID);
                //** http://api.openweathermap.org/data/2.5/weather?q={0},us&appid={1}&units=imperial", city, APPID);

                try
                {
                    var json = web.DownloadString(url);
                    var result = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                    WeatherInfo.root outPut = result;

                    lblCity.Text = string.Format("{0}", outPut.name);
                    lblCountry.Text = string.Format("{0}", outPut.sys.country);
                    lblTemp.Text = string.Format("{0:0}\u00B0 " + "F", outPut.main.temp);

                    lblCoord.Text = string.Format("(Longitude: {0}  Latitude: {1})", outPut.coord.lon, outPut.coord.lat);
                    lblSunrise.Text = string.Format("Sunrise: {0}", getDate(outPut.sys.sunrise).TimeOfDay);
                    lblSunset.Text = string.Format("Sunset: {0}", getDate(outPut.sys.sunset).TimeOfDay);
                    lblHigh.Text = string.Format("{0:0}\u00B0 " + "F", outPut.main.temp_max);
                    lblLow.Text = string.Format("{0:0}\u00B0 " + "F", outPut.main.temp_min);

                    string URL = "https://mir-s3-cdn-cf.behance.net/project_modules/disp/8f342f30971807.563b2b138deaa.gif";
                    picWeather1.Load(URL);

                    picSunrise.Load("http://openweathermap.org/img/w/01d.png");
                    picSunset.Load("http://openweathermap.org/img/w/01n.png");
                }
                catch (Exception)
                {
                    MessageBox.Show(txtSearchCity.Text + " not found.\r\nPlease enter correct city.");
                }
            }        
        }

        // For Forecast Weather inf0
        WeatherForecast forecast;
       
        void getForecast(string city)
        {
            int day = 5;
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&appid={1}&units=imperial&cnt={2}", city, APPID, day);

            using (WebClient web = new WebClient())
            {
                try
                {
                    var json = web.DownloadString(url);
                    var Object = JsonConvert.DeserializeObject<WeatherForecast>(json);

                    forecast = Object;

                    string date2 = getDate(forecast.list[1].dt).ToLongDateString(); //returning day
                    string icon1 = forecast.list[1].weather[0].icon;
                    lblDay2.Text = string.Format("{0}", date2.Substring(0, date2.Length - 6)); // Day without year
                    lblCond2.Text = string.Format("{0}", forecast.list[1].weather[0].main); //weather condition
                    lblDes2.Text = string.Format("{0}", forecast.list[1].weather[0].description); //weather description
                    lblTemp2.Text = string.Format("{0:0}\u00B0/" + "{1:0}\u00B0", forecast.list[1].temp.max, forecast.list[1].temp.min); //weather temp
                    lblWind2.Text = string.Format("Wind: {0} m/h", forecast.list[1].speed); //weather wind speed
                    picWeather2.Load("http://openweathermap.org/img/w/" + icon1 + ".png");

                    string date3 = getDate(forecast.list[2].dt).ToLongDateString();//returning day
                    string icon2 = forecast.list[2].weather[0].icon;
                    lblDay3.Text = string.Format("{0}", date3.Substring(0, date3.Length - 6)); // Day without year
                    lblCond3.Text = string.Format("{0}", forecast.list[2].weather[0].main); //weather condition
                    lblDes3.Text = string.Format("{0}", forecast.list[2].weather[0].description); //weather description
                    lblTemp3.Text = string.Format("{0:0}\u00B0/" + "{1:0}\u00B0", forecast.list[2].temp.max, forecast.list[2].temp.min); //weather temp
                    lblWind3.Text = string.Format("Wind: {0} m/h", forecast.list[2].speed); //weather wind speed
                    picWeather3.Load("http://openweathermap.org/img/w/" + icon2 + ".png");

                    string date4 = getDate(forecast.list[3].dt).ToLongDateString();//returning day
                    string icon3 = forecast.list[3].weather[0].icon;
                    lblDay4.Text = string.Format("{0}", date4.Substring(0, date4.Length - 6)); // Day without year
                    lblCond4.Text = string.Format("{0}", forecast.list[3].weather[0].main); //weather condition
                    lblDes4.Text = string.Format("{0}", forecast.list[3].weather[0].description); //weather description
                    lblTemp4.Text = string.Format("{0:0}\u00B0/" + "{1:0}\u00B0", forecast.list[3].temp.max, forecast.list[3].temp.min); //weather temp
                    lblWind4.Text = string.Format("Wind: {0} m/h", forecast.list[3].speed); //weather wind speed
                    picWeather4.Load("http://openweathermap.org/img/w/" + icon3 + ".png");

                    string date5 = getDate(forecast.list[4].dt).ToLongDateString();//returning day
                    string icon4 = forecast.list[4].weather[0].icon;
                    lblDay5.Text = string.Format("{0}", date5.Substring(0, date5.Length - 6)); // Day without year
                    lblCond5.Text = string.Format("{0}", forecast.list[4].weather[0].main); //weather condition
                    lblDes5.Text = string.Format("{0}", forecast.list[4].weather[0].description); //weather description
                    lblTemp5.Text = string.Format("{0:0}\u00B0/" + "{1:0}\u00B0", forecast.list[4].temp.max, forecast.list[4].temp.min); //weather temp
                    lblWind5.Text = string.Format("Wind: {0} m/h", forecast.list[4].speed); //weather wind speed
                    picWeather5.Load("http://openweathermap.org/img/w/" + icon4 + ".png");

                    //For Today's Section, additional data from WeatherForecast Class
                    string icon0 = forecast.list[0].weather[0].icon;
                    lblTodayDate.Text = string.Format("{0}", getDate(forecast.list[0].dt).ToLongDateString());
                    lblCondition1.Text = string.Format("{0}", forecast.list[0].weather[0].main);
                    lblDescription1.Text = string.Format("{0}", forecast.list[0].weather[0].description);
                    lblHumidity1.Text = string.Format("{0} %", forecast.list[0].humidity);
                    lblWindSpeed1.Text = string.Format("{0} m/h", forecast.list[0].speed);
                    picWeather1.Load("http://openweathermap.org/img/w/" + icon0 + ".png");

                }
                catch (Exception)
                {
                
                }
            }
        }

        DateTime getDate(double millisecond)
        {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisecond).ToLocalTime();
            return day;      
        }

    }
}
