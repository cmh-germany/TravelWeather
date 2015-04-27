using System;
using System.Globalization;
using System.Windows.Forms;

namespace TravelWeather
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentCulture = CultureInfo.CreateSpecificCulture("de-DE");
            Application.Run(new FormMain());
        }
    }
}
