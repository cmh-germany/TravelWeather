using System;
using System.Collections.Generic;
using System.Linq;
using Google.GData.Calendar;
using Google.GData.Extensions;
using System.IO;

namespace TravelWeather
{
    class CalendarGoogle : CalendarBase
    {
        private string username;
        private string password;

        public CalendarGoogle()
        {
            this.load = true;
            location = new Dictionary<DateTime, string>();
            CalendarService myService = new CalendarService("example");

            this.requestUsernameAndPassword();



            myService.setUserCredentials(this.username+"@gmail.com", this.password);

            //CalendarQuery query = new CalendarQuery();
            //query.Uri = new Uri("https://www.google.com/calendar/feeds/default/allcalendars/full");
            //CalendarFeed resultFeed = (CalendarFeed) myService.Query(query);
            //Console.WriteLine("Your calendars:\n");
            //foreach (CalendarEntry entry in resultFeed.Entries)
            //{
            //    Console.WriteLine(entry.Title.Text + "\n");
            //}

            EventQuery query2 = new EventQuery();
            string feedUrl = "https://www.google.com/calendar/feeds/"+this.username+"@gmail.com/private/full";

            EventQuery oEventQuery = new EventQuery(feedUrl);
            oEventQuery.ExtraParameters = Guid.NewGuid().ToString();

            oEventQuery.StartTime = new DateTime(2013, 7, 10);
            oEventQuery.EndTime = new DateTime(2013, 7, 15);

            Google.GData.Calendar.EventFeed oEventFeed = myService.Query(oEventQuery);

            //Delete Related Events
            foreach (EventEntry oEventEntry in oEventFeed.Entries)
            {
                //Do your stuff here
                Where loc = oEventEntry.Locations[0];
                When time = oEventEntry.Times[0];
                if (loc.ValueString != null && loc.ValueString != "" && oEventEntry.Times.Count != 0)
                {
                    DateTime date = time.StartTime;
                    DateTime dateWithoutTime = new DateTime(date.Year, date.Month, date.Day);
                    
                    Console.WriteLine(oEventEntry.Title.Text + "(" + dateWithoutTime + ") : " + loc.ValueString);
                    if (!location.ContainsKey(dateWithoutTime))
                        location.Add(dateWithoutTime, loc.ValueString);
                }
            }

            //EventQuery myQuery = new EventQuery(feedUrl);
   

            //EventFeed myResultsFeed = myService.Query(myQuery);


            //for (int i=0; i<myResultsFeed.Entries.Count();i++){
            //    Console.WriteLine(myResultsFeed.Entries[i].Title.Text);
            //    AtomEntry firstMatchEntry = myResultsFeed.Entries[i];

            //}
        }

        private void requestUsernameAndPassword()
        {
            bool found = this.tryReadPassFile();
            if (!found)
            {
                List<string> promptValues = Prompt.ShowDialog(2, "Please enter username and password", "Request", true);
                this.username = promptValues.ElementAt(0);
                this.password = promptValues.ElementAt(1);

                bool saveToFile = true;
                if (saveToFile)
                {
                    string[] lines = { this.username, this.password };
                    System.IO.File.WriteAllLines(@"pass.txt", lines);
                }
            }
            

        }

        private bool tryReadPassFile()
        {
            if (File.Exists(@"pass.txt"))
            {
                string[] lines = System.IO.File.ReadAllLines(@"pass.txt");
                if (lines.Length == 2)
                {
                    this.username = lines[0];
                    this.password = lines[1];
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
