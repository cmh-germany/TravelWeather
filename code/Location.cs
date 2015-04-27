using System;

namespace TravelWeather
{
    class Location
    {
        private string cityName;
        private string countryName;
        private int id;
        private string idSource;
        double latitude, longitude;

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
            this.cityName = countryName = idSource = "";
            this.id = -1;
            this.latitude = this.longitude = 0.0;
        }

    }

}
