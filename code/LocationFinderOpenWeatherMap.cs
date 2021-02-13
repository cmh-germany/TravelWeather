using System;
using System.Collections.Generic;
using System.Xml;

namespace TravelWeather
{
    class LocationFinderOpenWeatherMap : LocationFinderBase
    {
        protected Dictionary<int, String> searchModeString;

        public LocationFinderOpenWeatherMap(string name)
        {
            this.parseName(name);
            this.searchMode = 0;
            searchModeString = new Dictionary<int,string>();
            searchModeString.Add(0, "accurate");
            searchModeString.Add(1, "like");
        }

        public override void find(){
            String url = "";
            String value = "";
            searchModeString.TryGetValue(searchMode, out value);
            if (countryName == "")
            {
                url = "http://api.openweathermap.org/data/2.5/find?q=" + this.cityName + "&type=" + value +"&mode=xml";
            }
            else
            {
                url = "http://api.openweathermap.org/data/2.5/find?q=" + this.cityName + "," + this.countryName + "&type=" + value + "&mode=xml";
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlNodeList listOfCities = doc.SelectNodes("/cities/list/item");
            Console.WriteLine(this.cityName + "# cities: " + listOfCities.Count);

            foreach (XmlNode cityList in listOfCities)
            {
                XmlNode city = cityList.FirstChild;
                XmlNode coord = city["coord"];
                XmlNode country = city["country"];
                XmlNode sun = city["sun"];
                XmlAttributeCollection cityAttributes = city.Attributes;
                Location loc = new Location(city.Attributes["name"].Value, country.InnerText, int.Parse(city.Attributes["id"].Value), "OpenWeatherMap", double.Parse(coord.Attributes["lon"].Value), double.Parse(coord.Attributes["lat"].Value));
                this.possibleLocations.Add(loc);
            }

        }
    }
}
