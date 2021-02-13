using System;
using System.Collections.Generic;

namespace TravelWeather
{
    class WeatherModel
    {
        public double temperature { get; set; }
        public double temperatureMin { get; set; }
        public double temperatureMax { get; set; }
        public double cloudyness { get; set; }
        public double precipitation { get; set; }
        public string precipitationType { get; set; }
        public string weatherServiceSource { get; set; }
        public DateTime lastUpdated { get; set; }

        public WeatherModel(string s, double t, double c, double p)
        {
            weatherServiceSource = s;
            temperature = t;
            cloudyness = c;
            precipitation = p;
        }

        public WeatherModel(string s, double t1, double t2, double c, double p, string pt)
        {
            weatherServiceSource = s;
            this.setTemperature(t1, t2);
            cloudyness = c;
            precipitation = p;
            precipitationType = pt;
        }

        /// <summary>
        ///  Returns weather as string for specific day
        /// </summary>
        public string getWeatherString()
        {
            if (this.precipitation != -1 && this.cloudyness != -1)
            {
                if (this.precipitation > 0.5)
                    return "rainy";
                else if (this.cloudyness < 20)
                    return "sunny";
                else if (this.cloudyness < 60)
                    return "cloudySun";
                else
                    return "cloudy";
            }
            else
                return "";
        }

        public void setTemperature(double t1, double t2)
        {
            temperatureMin = t1;
            temperatureMax = t2;
        }

    }
}
