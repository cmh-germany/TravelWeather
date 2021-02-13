using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

//todo implement import of ics files
//todo implement more weather services
//todo resolve multiple locations per day
//todo exception handling of location does not exist (or was not found)
//todo eventually built in lookup in geonames/OSM
//todo exception handling if no WWW connection exists
//todo intelligent location-handling if no information is available
//todo try to read location from description
//todo graphical display of weather information similar to Kachelmann
//todo Multi-Threading (weather reading processing)

namespace TravelWeather
{
    public partial class FormMain : Form
    {
        private director aDirector;
        //todo: add all table information in extra class
        private List<DateTime> dateList = new List<DateTime>();
        private List<Label> dateLabelList = new List<Label>();
        private List<TextBox> locationTextBoxList = new List<TextBox>();
        private List<PictureBox> weatherPictureBoxList = new List<PictureBox>();
        private List<Label> temperatureMinLabelList = new List<Label>();
        private List<Label> temperatureMaxLabelList = new List<Label>();
        private List<Label> cloudynessLabelList = new List<Label>();
        private List<Label> precipitationLabelList = new List<Label>();
        private List<String> tableRowCaptions;
        private TableLayoutPanel tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();

        const int daysForecast = 7;

        private Dictionary<string, Image> weatherSymbol;


        public FormMain()
        {
            InitializeComponent();
        }

        private void button_getWeather_Click(object sender, EventArgs e)
        {

            aDirector.setWeatherSource((director.weatherSourceType)comboBox_weatherSource.SelectedIndex);
            aDirector.setLocationFinder((director.locationFinderType)comboBox_locationSource.SelectedIndex);
            aDirector.setCalendarSource((director.calendarType)comboBox_calendarSource.SelectedIndex);
            aDirector.parseLocations(this.getManualLocations());
            aDirector.readWeather();

            Dictionary<DateTime, WeatherModel> dateAndWeather = aDirector.getWeather();
            int count = 0;
            foreach (KeyValuePair<DateTime, WeatherModel> entry in dateAndWeather)
            {
                displayWeather(count, entry.Value);
                count++;
            }

        }

        private void displayWeather(int column, WeatherModel wm)
        {
            weatherPictureBoxList.ElementAt(column).Image = weatherSymbol[wm.getWeatherString()];
            weatherPictureBoxList.ElementAt(column).SizeMode = PictureBoxSizeMode.Zoom;

            temperatureMinLabelList.ElementAt(column).Text = wm.temperatureMin.ToString("N0") + " °C";
            temperatureMaxLabelList.ElementAt(column).Text = wm.temperatureMax.ToString("N0") + " °C";
            cloudynessLabelList.ElementAt(column).Text = wm.cloudyness.ToString("N0") + " %";
            precipitationLabelList.ElementAt(column).Text = wm.precipitation.ToString("N1") + " mm";
        }


        private void initialize()
        {
            aDirector = new director();
            aDirector.CalendarReady += new ChangedEventHandler(addLocations);
            aDirector.WeatherReady += new ChangedEventHandler(paintWeather);

            List<String> locationDefault = new List<String>(){
            "Magdeburg", "Berlin", "Frankfurt", "New York", "Sydney", "Paris","Mannheim"
            };

            tableRowCaptions = new List<String>(){
                "Date","Location","Weather","Min. temperature","Max. temperature","Cloudyness","Precipitation"
            };

            //+1 for captions
            this.tableLayoutPanelMain.ColumnCount = daysForecast + 1;
            this.tableLayoutPanelMain.RowCount = tableRowCaptions.Count;


            for (int i = 0; i < this.tableLayoutPanelMain.ColumnCount; i++)
            {
                this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / this.tableLayoutPanelMain.ColumnCount));
            }
            for (int i = 0; i < this.tableLayoutPanelMain.RowCount; i++)
            {
                this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / this.tableLayoutPanelMain.RowCount));
            }
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(25, 125);
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(900, 300);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.tableLayoutPanelMain.PerformLayout();

            //captions
            for (int i = 0; i < tableRowCaptions.Count(); i++)
            {
                Label captionCur = new Label();
                captionCur.Text = tableRowCaptions.ElementAt(i);
                this.tableLayoutPanelMain.Controls.Add(captionCur, 0, i);
            }

            for (int i = 1; i < daysForecast + 1; i++)
            {
                dateList.Add(DateTime.Today.AddDays(i - 1).AddHours(12));

                CreateAndAddLabelToList(dateList.Last().ToString("ddd d MMM"), dateLabelList);

                TextBox lLoc = new TextBox();
                lLoc.Text = locationDefault.ElementAt(i - 1);
                locationTextBoxList.Add(lLoc);

                PictureBox pWeather = new PictureBox();
                weatherPictureBoxList.Add(pWeather);

                CreateAndAddLabelToList("", temperatureMinLabelList);
                CreateAndAddLabelToList("", temperatureMaxLabelList);
                CreateAndAddLabelToList("", cloudynessLabelList);
                CreateAndAddLabelToList("", precipitationLabelList);

                int row = 0;
                this.tableLayoutPanelMain.Controls.Add(this.dateLabelList.Last(), i, row++);
                this.tableLayoutPanelMain.Controls.Add(this.locationTextBoxList.Last(), i, row++);
                this.tableLayoutPanelMain.Controls.Add(this.weatherPictureBoxList.Last(), i, row++);
                this.tableLayoutPanelMain.Controls.Add(this.temperatureMinLabelList.Last(), i, row++);
                this.tableLayoutPanelMain.Controls.Add(this.temperatureMaxLabelList.Last(), i, row++);
                this.tableLayoutPanelMain.Controls.Add(this.cloudynessLabelList.Last(), i, row++);
                this.tableLayoutPanelMain.Controls.Add(this.precipitationLabelList.Last(), i, row++);
            }

            weatherSymbol = new Dictionary<string, Image>(){
                {"sunny", global::TravelWeather.Properties.Resources.sunny},
                 {"cloudySun", global::TravelWeather.Properties.Resources.sunnyAndClouds},
                  {"rainy", global::TravelWeather.Properties.Resources.rain},
                  {"cloudy", global::TravelWeather.Properties.Resources.cloudy},
                   {"snowy", global::TravelWeather.Properties.Resources.snow},
                   {"thunderstorm", global::TravelWeather.Properties.Resources.thunderstorm}
            };
        }

        private void CreateAndAddLabelToList(String text, List<Label> list)
        {
            Label aLabel = new Label();
            aLabel.Text = text;
            list.Add(aLabel);
        }

        private void addLocations(object sender, EventArgs e)
        {
            CalendarBase cal = this.aDirector.getCalendar();
            if (cal.wasLoad())
            {
                DateTime cur = DateTime.Today;
                for (int i = 0; i < daysForecast; i++)
                {
                    //Console.WriteLine(cur);
                    string curLocation = cal.getLocation(cur);

                    if (curLocation != "-1")
                        locationTextBoxList.ElementAt(i).Text = cal.getLocation(cur);
                    else
                        locationTextBoxList.ElementAt(i).Text = "";
                    cur = cur.AddDays(1);
                }
            }
            else
            {
                MessageBox.Show("No calendar is loaded!");
            }
        }

        private void paintWeather(object sender, EventArgs e)
        {

        }

        private void button_readCalendar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented");
        }

        private Dictionary<DateTime, String> getManualLocations()
        {
            Dictionary<DateTime, String> dateAndLocation = new Dictionary<DateTime, string>();
            if (locationTextBoxList.Count == dateList.Count)
            {
                for (int i = 0; i < locationTextBoxList.Count; i++)
                {
                    dateAndLocation.Add(dateList.ElementAt(i), locationTextBoxList.ElementAt(i).Text);
                }

            }
            else
            {
                Console.WriteLine("location.Count != dateDate.Count");
            }
            return dateAndLocation;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBox_weatherSource.SelectedIndex = 0;
            comboBox_calendarSource.SelectedIndex = 0;
            comboBox_locationSource.SelectedIndex = 0;
            this.initialize();
        }

        {

        }

        private void comboBox_calendarSource_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
