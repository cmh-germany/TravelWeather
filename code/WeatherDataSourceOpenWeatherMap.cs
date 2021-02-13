using System;
using System.Globalization;
using System.Net;
using System.IO;
using System.Text.Json;

namespace TravelWeather
{
    class WeatherDataSourceOpenWeatherMap : WeatherDataSourceBase
    {
        public WeatherDataSourceOpenWeatherMap(Location l, DateTime requestedDate) { this.service = 0; this.location = l; this.requestedDate = requestedDate; }
        protected String APIKey = "";

        public class Rootobject
        {
            public float lat { get; set; }
            public float lon { get; set; }
            public string timezone { get; set; }
            public int timezone_offset { get; set; }
            public Current current { get; set; }
            public Daily[] daily { get; set; }
            public Alert[] alerts { get; set; }
        }

        public class Current
        {
            public int dt { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
            public float temp { get; set; }
            public float feels_like { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public float dew_point { get; set; }
            public float uvi { get; set; }
            public int clouds { get; set; }
            public int visibility { get; set; }
            public float wind_speed { get; set; }
            public int wind_deg { get; set; }
            public Weather[] weather { get; set; }
            public Snow snow { get; set; }
        }

        public class Snow
        {
            public float _1h { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Daily
        {
            public int dt { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
            public Temp temp { get; set; }
            public Feels_Like feels_like { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public float dew_point { get; set; }
            public float wind_speed { get; set; }
            public int wind_deg { get; set; }
            public Weather1[] weather { get; set; }
            public int clouds { get; set; }
            public float pop { get; set; }
            public float snow { get; set; }
            public float uvi { get; set; }
            public float rain { get; set; }
        }

        public class Temp
        {
            public float day { get; set; }
            public float min { get; set; }
            public float max { get; set; }
            public float night { get; set; }
            public float eve { get; set; }
            public float morn { get; set; }
        }

        public class Feels_Like
        {
            public float day { get; set; }
            public float night { get; set; }
            public float eve { get; set; }
            public float morn { get; set; }
        }

        public class Weather1
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Alert
        {
            public string sender_name { get; set; }
            public string _event { get; set; }
            public int start { get; set; }
            public int end { get; set; }
            public string description { get; set; }
        }


        public void parseWeatherData()
        {
            String url = "https://api.openweathermap.org/data/2.5/onecall?lat=" + this.location.latitude + "&lon=" + this.location.longitude + "&exclude=hourly,minutely&units=metric&cnt=7&APPID=" + this.APIKey;

            //decimal delimiter is .
            CultureInfo culture = new CultureInfo("en-US");

            // Load the document.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            if (webRequest == null)
            {
                return;
            }

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    var allData = JsonSerializer.Deserialize <Rootobject>(contributorsAsJson);
                    foreach (Daily d in allData.daily)
                    {
                        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(d.dt);
                        DateTime dateTime = dateTimeOffset.UtcDateTime;
                        if ((dateTime - this.requestedDate).TotalHours < 12)
                        {
                            double temperatureMin = d.temp.min;
                            double temperatureMax = d.temp.max;
                            double temperatureDay = d.temp.day;
                            double cloudyness = d.clouds;
                            double precipitation = 0.0 ;
                            string precipitationType = "";
                            if (d.rain > 0)
                            {
                                precipitation = d.rain;
                                precipitationType = "rain";
                            }
                            else if (d.snow > 0)
                            {
                                precipitation = d.snow;
                                precipitationType = "snow";
                            }
                            model = new WeatherModel("OpenWeatherMap", temperatureMin, temperatureMax, cloudyness, precipitation, precipitationType);
                        }
                    }
                }
            }
        }
    }
}
