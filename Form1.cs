using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace laba5
{
    public partial class Form1 : Form
    {
        static Random rand = new Random();
        int g = 10;
        private double timeInterval = 0.1;
        private Timer timer = new Timer();
        private List<string> NamesPlanets = new List<string>
        {
            "Венера","Меркурий","Земля","Уран","Нептун","Юпитер","Неизвестная"
        };
        public List<Planet> planets = new List<Planet>()
            {
                new Planet("Марс", rand.NextDouble()+rand.Next(0,4),rand.Next(0,1000),rand.Next(0,1000),rand.Next(-1,1)+rand.NextDouble(),rand.Next(-1,1)+rand.NextDouble(),Color.Red,10),
                new Planet("Юпитер", rand.NextDouble()+rand.Next(0,4),rand.Next(0,1000),rand.Next(0,1000),rand.Next(-1, 1) + rand.NextDouble(),rand.Next(-2,2),Color.Green,5),
                new Planet("Сатурн", rand.NextDouble()+rand.Next(0,4),rand.Next(0,1000),rand.Next(0,1000),rand.Next(-1,1)+rand.NextDouble(),rand.Next(-1,1)+rand.NextDouble(), Color.Yellow,3)
            };
        public Form1()
        {

            InitializeComponent();
            timer.Interval = 10; 
            timer.Tick += Timer_Tick!;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < planets.Count; i++)
            {
                for (int j = i + 1; j < planets.Count; j++)
                {
                    planets[i].CalculateForce(planets[j], g);
                    planets[j].CalculateForce(planets[i], g);
                }
            }

            foreach (Planet planet in planets)
            {
                planet.UpdatePosition(timeInterval);
                if (planet.X < 0) planet.X = panel1.Width; 
                if (planet.X > panel1.Width) planet.X = 0; 
                if (planet.Y < 0) planet.Y = panel1.Height;
                if (planet.Y > panel1.Height) planet.Y = 0;
            }

            panel1.Invalidate();
        }
        private void panel1_Paint(object sender, PaintEventArgs e) 
        {
            Graphics g = e.Graphics;

            if (checkBoxTraectory.Checked)
            {
                foreach (Planet planet in planets)
                {
                    if (planet.Trajectory.Count > 1)
                    {
                        g.DrawLines(new Pen(planet.Color, 1), planet.Trajectory.ToArray());
                    }
                }
            }

            foreach (Planet planet in planets)
            {
                g.FillEllipse(new SolidBrush(planet.Color), (float)planet.X - planet.Radius, (float)planet.Y - planet.Radius, 2 * planet.Radius, 2 * planet.Radius);
            }
        }
        private void checkBoxTraectory_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxTraectory.Checked)
            {
                foreach (Planet planet in planets)
                {
                    planet.ClearTrajectory();
                }
            }
            panel1.Invalidate(); 
        }
        private void comboBoxCountBody_Change(object sender, EventArgs e)
        {
            if (comboBoxCountBody.SelectedItem != null)
            {
                int count = Convert.ToInt32(comboBoxCountBody.SelectedItem);
                if (planets.Count > count)
                {
                    while (planets.Count > count)
                    {
                        planets.RemoveAt(planets.Count - 1);
                    }
                }
                else
                {
                    int planetsToAdd = count - planets.Count;
                    for (int i = 0; i < planetsToAdd; i++)
                    {
                        string planetName = NamesPlanets[i % NamesPlanets.Count];
                        Color randomColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                        int randomRadius = rand.Next(5, 20);
                        planets.Add(new Planet(planetName, rand.NextDouble() + rand.Next(0, 4), rand.Next(0, 100), rand.Next(0, 100), rand.Next(-1, 1) + rand.NextDouble(), rand.Next(-1, 1) + rand.NextDouble(), randomColor, randomRadius));
                    }
                }
            }
            panel1.Invalidate();
        }
        //
        //StartButton
        //
        private void buttonStart_MouseEnter(object sender, EventArgs e)
        {
            buttonStart.BackColor = Color.LightSkyBlue;
        }
        private void buttonStart_MouseLeave(object sender, EventArgs e)
        {
            buttonStart.BackColor = Color.LightGray;
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer.Start();
        }
        //
        //StopButton
        //
        private void buttonStop_MouseEnter(object sender, EventArgs e)
        {
            buttonStop.BackColor = Color.IndianRed;
        }
        private void buttonStop_MouseLeave(object sender, EventArgs e)
        {
            buttonStop.BackColor = Color.LightGray;
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
        //
        //SettingButton
        //
        private void buttonSettings_MouseEnter(object sender, EventArgs e)
        {
            buttonSettings.BackColor = Color.LightSkyBlue;
        }
        private void buttonSettings_MouseLeave(object sender, EventArgs e)
        {
            buttonSettings.BackColor = Color.LightGray;
        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Form2 form2 = new Form2(planets);
            form2.ShowDialog();
        }
    }
}
