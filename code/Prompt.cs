using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TravelWeather
{
    public static class Prompt
    {
        public static List<string> ShowDialog(int numberRequests, string text, string caption, bool password=false)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 120+numberRequests*30;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20,  Width = 400, Text = text };
            List<TextBox> inputBoxes = new List<TextBox>();
            for (int i = 0; i < numberRequests; i++)
            {
                TextBox textBox = new TextBox() { Left = 50, Top = 50+i*30, Width = 400 };
                inputBoxes.Add(textBox);
            }
            if (password)
            {
                inputBoxes.Last().PasswordChar = '*';
            }
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 50+numberRequests*30 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            for (int i = 0; i < numberRequests; i++)
            {
                prompt.Controls.Add(inputBoxes.ElementAt(i));
            }
            prompt.ShowDialog();
            List<string> values = new List<string>();
            for (int i = 0; i < numberRequests; i++)
            {
                values.Add(inputBoxes.ElementAt(i).Text);
            }
            return values;
        }
    }
}
