using System;
using System.Globalization;
using System.Xml;

namespace TravelWeather
{
    class WeatherDataSourceOpenWeatherMap : WeatherDataSourceBase
    {
        public WeatherDataSourceOpenWeatherMap(String l) { this.service = 0; this.location = l; }

        public void parseWeatherData()
        {
            String url = "http://api.openweathermap.org/data/2.5/forecast/daily?q=" + this.location + "&mode=xml&units=metric&cnt=7";

            //Console.WriteLine("URL: "+url);

            //decimal delimiter is .
            CultureInfo culture = new CultureInfo("en-US");

            // Load the document. 
            XmlDocument doc = new XmlDocument();
            try {
                doc.Load(url);
                // Retrieve all temperature tags. 
                XmlNodeList forecast = doc.SelectNodes("/weatherdata/forecast/time");
            
                foreach (XmlNode day in forecast)
                {
                    XmlAttributeCollection dayAttribute = day.Attributes;
                    //Console.WriteLine(dayAttribute["day"].Value);
                    DateTime curDate = DateTime.Parse(dayAttribute["day"].Value);
                    //Console.WriteLine(curDate.ToString()+" "+day["temperature"].Attributes["day"].Value);
                    double temperatureMin = double.Parse(day["temperature"].Attributes["min"].Value, culture.NumberFormat);
                    //System.Console.WriteLine("min: " + day["temperature"].Attributes["min"].Value, culture.NumberFormat);
                    double temperatureMax = double.Parse(day["temperature"].Attributes["max"].Value, culture.NumberFormat);
                    //System.Console.WriteLine("max: " + temperatureMax);
                    double precipitation = 0;
                    string precipiationType = "";
                    if (day["precipitation"].HasAttributes)
                    {
                        precipitation = double.Parse(day["precipitation"].Attributes["value"].Value, culture.NumberFormat);
                        precipiationType = day["precipitation"].Attributes["type"].Value;
                    }
                    double cloudyness = int.Parse(day["clouds"].Attributes["all"].Value);
                    //Console.WriteLine(day["temperature"].Attributes["day"].Value + " " + precipitation + " " + day["clouds"].Attributes["all"].Value);
                    model = new WeatherModel("OpenWeatherMap", temperatureMin, temperatureMax, cloudyness, precipitation, precipiationType); 
                } 
            }
            catch (XmlException e)
            {
                //this report had an error loading!
                Console.WriteLine(e.Message);
            }
        }
    }
}
