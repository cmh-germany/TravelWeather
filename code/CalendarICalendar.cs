using System;
using System.Collections.Generic;

namespace TravelWeather
{
    class CalendarICalendar : CalendarBase
    {
        private string filename;

        public CalendarICalendar(string fn)
        {
            this.load = true;
            location = new Dictionary<DateTime, string>();
            this.filename = fn;
        }

    }
}
