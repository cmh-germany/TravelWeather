using System;

namespace TravelWeather
{
    class Location
    {
        public string cityName { get; }
        public string countryName;
        public int id { get; }
        private string idSource;
        public double latitude { get; }
        public double longitude { get; }

        public Location()
        {
            this.init();
        }

        public Location(string cityName)
        {
            this.init();
            this.cityName = cityName;
        }

        public Location(string cityName, string countryName)
        {
            this.init();
            this.cityName = cityName;
            this.countryName = countryName;
        }

        public Location(string cityName, string countryName, int id, string idSource, double longitude, double latitude)
        {
            this.init();
            this.cityName = cityName;
            this.countryName = countryName;
            this.id = id;
            this.idSource = idSource;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public void toString()
        {
            Console.WriteLine(cityName + ", " + countryName + "(" + id + ", " + idSource + "), lon: " + longitude + " lat: " + latitude);
        }

        public string getCityName()
        {
            return this.cityName;
        }

        private void init()
        {
        }

    }

}
