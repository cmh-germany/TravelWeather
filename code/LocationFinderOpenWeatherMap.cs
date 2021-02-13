using System;
using System.Collections.Generic;
using System.Xml;
using System.Globalization;

namespace TravelWeather
{
    class LocationFinderOpenWeatherMap : LocationFinderBase
    {
        protected Dictionary<int, String> searchModeString;
        protected String APIKey = "";

        public LocationFinderOpenWeatherMap(string name)
        {
            this.parseName(name);
            this.searchMode = 0;
            searchModeString = new Dictionary<int, string>();
            searchModeString.Add(0, "accurate");
            searchModeString.Add(1, "like");
        }

        public override void find()
        {
            //decimal delimiter is .
            CultureInfo culture = new CultureInfo("en-US");
            String value = "";
            searchModeString.TryGetValue(searchMode, out value);
            String search = this.cityName;
            if (String.IsNullOrEmpty(countryName) == false)
            {
                search += "," + this.countryName;
            }
            String url = "https://api.openweathermap.org/data/2.5/find?q=" + search + "&type=" + value + "&mode=xml" + "&APPID=" + this.APIKey;
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
                Location loc = new Location(city.Attributes["name"].Value, country.InnerText, int.Parse(city.Attributes["id"].Value), "OpenWeatherMap", double.Parse(coord.Attributes["lon"].Value, culture.NumberFormat), double.Parse(coord.Attributes["lat"].Value, culture.NumberFormat));
                loc.toString();
                this.possibleLocations.Add(loc);
            }
        }
    }
}
