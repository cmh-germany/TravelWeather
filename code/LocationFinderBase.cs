using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelWeather
{
    class LocationFinderBase
    {
        protected string cityName, countryName;
        protected List<Location> possibleLocations;
        protected int searchMode;
        

        public LocationFinderBase()
        {
            cityName = countryName = "";
            possibleLocations = new List<Location>();
            searchMode = 0;
        }

        public virtual void find()
        {

        }

        public List<Location> getLocations()
        {
            return this.possibleLocations;
        }

        public Location getFirstLocation()
        {
            if (this.possibleLocations.Count > 0)
                return this.possibleLocations.First();
            else
                return new Location();
        }

        protected void parseName(String name)
        {
            if (name.Contains(',')){
                string [] splittedName = name.Split(',');
                if (splittedName.Count() == 2)
                {
                    cityName = splittedName[0];
                    countryName = splittedName[1];
                }
                else
                {
                    cityName = splittedName[0];
                    for (int i = 1; i < splittedName.Count(); i++)
                    {
                        countryName += splittedName[i];
                    }
                }
            }
            else {
                cityName = name;
            }
        }

    }
}
