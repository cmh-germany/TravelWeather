using System;

namespace TravelWeather
{
    //Weather Underground
    //    OpenWeatherMap
    //    The Weather Channel
    //World Weather Online
    //Yahoo Weather
    //Wetter.com
    //Norwegian Meteorological Institute
    class WeatherDataSourceBase
    {
        public WeatherDataSourceBase() { }

        protected int service;
        protected Location location;
        protected WeatherModel model = null;
        protected DateTime requestedDate;

        public WeatherModel getWeatherModel() { return model; }



    }
}
