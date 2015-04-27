using System;

namespace TravelWeather
{
    class WeatherDataSourceBase
    {
        public WeatherDataSourceBase() { }

        protected int service;
        protected String location;
        protected WeatherModel model=null;

        public WeatherModel getWeatherModel(){return model;}



    }
}
