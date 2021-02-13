using System;
using System.Collections.Generic;

namespace TravelWeather
{
    // A delegate type for hooking up change notifications.
    public delegate void ChangedEventHandler(object sender, EventArgs e);
    class director
    {
        public enum locationFinderType { OpenWeatherMap = 0, OpenStreetMap = 1, GeoNames = 2 };
        public enum weatherSourceType { WeatherUnderground = 0, OpenWeatherMap = 1, TheWeatherChannel = 2, WorldWeatherOnline = 3, YahooWeather = 4, WetterDotCom = 5, yrDotNo = 6 };
        public enum calendarType { Google = 0, iCalendar = 1 };

        private CalendarBase _cal;
        private Dictionary<DateTime, WeatherModel> _dateAndWeather;

        private locationFinderType _locationFinderSource;
        private calendarType _calendarSource;
        private weatherSourceType _weatherSource;

        Dictionary<DateTime, Location> _dateAndFoundLocation;

        public event ChangedEventHandler CalendarReady;
        public event ChangedEventHandler WeatherReady;

        public director()
        {
        }

        public Dictionary<DateTime, string> getAllLocationsFromCalendar()
        {
            return _cal.getAllLocations();
        }

        public Location getMostProbableLocation(string name)
        {
            LocationFinderBase finder;
            //OpenWeatherMap
            if (_locationFinderSource == locationFinderType.OpenWeatherMap)
            {
                finder = new LocationFinderOpenWeatherMap(name);
                finder.find();
                return finder.getFirstLocation();
            }
            else
            {
                throw new Exception("_locationFinderSource unknown");
            }
        }

        public void setLocationFinder(locationFinderType aLocationFinder)
        {
            _locationFinderSource = aLocationFinder;
        }

        public void setWeatherSource(weatherSourceType aWeatherSource)
        {
            _weatherSource = aWeatherSource;
        }

        public void setCalendarSource(calendarType aCalendarType)
        {
            _calendarSource = aCalendarType;
        }

        // Invoke the Changed event; called whenever list changes
        protected virtual void OnCalendarReady(EventArgs e)
        {
            if (CalendarReady != null)
                CalendarReady(this, e);
        }

        public void readCalendar(int type)
        {
            if (type == 0)
            {
                _cal = new CalendarGoogle();
                OnCalendarReady(EventArgs.Empty);
            }
            else if (type == 1)
            {
                System.Console.WriteLine("not yet implemented");
            }
            else
            {
                Console.WriteLine("Calendar Type not implemented yet");
            }
        }



        public WeatherModel readWeather(Location loc, DateTime date)
        {
            WeatherDataSourceOpenWeatherMap wm = new WeatherDataSourceOpenWeatherMap(loc, date);
            wm.parseWeatherData();
            return wm.getWeatherModel();
        }

        //First determine location (that might be ambigous), then read weather
        public void parseLocations(Dictionary<DateTime, String> dateAndlocationString)
        {
            _dateAndFoundLocation = new Dictionary<DateTime, Location>();
            string lastEntry = "";

            foreach (KeyValuePair<DateTime, String> kvp in dateAndlocationString)
            {
                if (lastEntry != kvp.Value)
                {
                    //first: determine location
                    Location curLocation = this.getMostProbableLocation(kvp.Value);
                    _dateAndFoundLocation.Add(kvp.Key, curLocation);

                }
                lastEntry = kvp.Value;
            }
        }

        //Read weather from known location
        public void readWeather()
        {
            _dateAndWeather = new Dictionary<DateTime, WeatherModel>();
            foreach (KeyValuePair<DateTime, Location> kvp in _dateAndFoundLocation)
            {
                //then: read weather based on location
                DateTime date = kvp.Key;
                Location curLocation = kvp.Value;
                if (curLocation != null)
                {
                    WeatherModel curWeather = this.readWeather(curLocation, date);
                    if (curWeather != null)
                    {
                        _dateAndWeather.Add(date, curWeather);
                    }
                    else
                    {
                        Console.Out.WriteLine("weather for location " + curLocation.ToString() + " not found");
                        _dateAndWeather.Add(kvp.Key, null);
                    }
                }
                else
                {
                    Console.Out.WriteLine("location not found");
                    _dateAndWeather.Add(kvp.Key, null);
                }
            }
        }

        public Dictionary<DateTime, WeatherModel> getWeather()
        {
            return _dateAndWeather;
        }



        public CalendarBase getCalendar()
        {
            return _cal;
        }
    }
}
