using System;
using System.Collections.Generic;


namespace TravelWeather
{
    class CalendarBase
    {
        protected Dictionary<DateTime, string> location;
        protected bool load;

        public CalendarBase()
        {

        }

        public string getLocation(DateTime t){
            string tOut;
            if (location.TryGetValue(t, out tOut))
            {
                return tOut;
            }
            else
                return "-1";
        }

        public Dictionary<DateTime, string> getAllLocations()
        {
            return location;
        }

        public bool wasLoad()
        {
            return load;
        }
        
    }
}
