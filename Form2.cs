using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba5
{
    public partial class Form2: Form
    {
        private List<Planet> _planets;
        private bool change = false;
        private Planet planet;
        public Form2(List<Planet> planets)
        {
            InitializeComponent();
            _planets = planets;
            InitializeComboBox();
        }
        private void InitializeComboBox()
        {
            comboBox1.DataSource = _planets;
            comboBox1.DisplayMember = "Name"; 
        }
        private void comboBoxPlanets_SelectedIndexChanged(object sender, EventArgs e)
        {
            Planet selectedPlanet = (Planet)comboBox1.SelectedItem!;
            if (change)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения?", "Выберите Да или Нет",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(textBoxMass.Text)) { textBoxMass.Text = "0,1"; }
                    if (string.IsNullOrEmpty(textBoxVX.Text)) { textBoxVX.Text = "0,1"; }
                    if (string.IsNullOrEmpty(textBoxVY.Text)) { textBoxVY.Text = "0,1"; }
                    if (string.IsNullOrEmpty(textBoxX.Text)) { textBoxX.Text = "0,1"; }
                    if (string.IsNullOrEmpty(textBoxY.Text)) { textBoxY.Text = "0,1"; }
                    planet.Mass = Convert.ToDouble(textBoxMass.Text);
                    planet.Vx = Convert.ToDouble(textBoxVX.Text);
                    planet.Vy = Convert.ToDouble(textBoxVY.Text);
                    planet.X = Convert.ToDouble(textBoxX.Text);
                    planet.Y = Convert.ToDouble(textBoxY.Text);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (selectedPlanet != null)
            {
                textBoxMass.Text = selectedPlanet.Mass.ToString();
                textBoxX.Text = selectedPlanet.X.ToString();
                textBoxY.Text = selectedPlanet.Y.ToString();
                textBoxVY.Text = selectedPlanet.Vy.ToString();
                textBoxVX.Text = selectedPlanet.Vx.ToString();
            }
            planet = selectedPlanet;
            change = false;
        }
        private void textMass_ChangeTextMass(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxMass.Text, out double mass))
            {
                
                textBoxMass.Text = mass.ToString();
                change = true;
            }
            else
            {
                textBoxMass.Text = "";
            }
        }
        private void textX_ChangeTextX(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxX.Text, out double x))
            {

                textBoxX.Text = x.ToString();
                change = true;
            }
            else
            {
                textBoxX.Text = "";
            }
        }
        private void textY_ChangeTextY(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxY.Text, out double y))
            {

                textBoxY.Text = y.ToString();
                change = true;
            }
            else
            {
                textBoxY.Text = "";
            }
        }
        private void textVX_ChangeTextVX(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxVX.Text, "^[a-zA-Z]+$"))
            {

                textBoxVX.Text = "";
            }
            else
            {
                change = true;
            }
        }
        private void textVY_ChangeTextVY(object sender, EventArgs e)
        {

            if (Regex.IsMatch(textBoxVY.Text, "^[a-zA-Z]+$"))
            {
                textBoxVY.Text = "";
            }
            else
            {
                change = true;
            }

        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            planet.Mass = Convert.ToDouble(textBoxMass.Text);
            planet.Vx = Convert.ToDouble(textBoxVX.Text);
            planet.Vy = Convert.ToDouble(textBoxVY.Text);
            planet.X = Convert.ToDouble(textBoxX.Text);
            planet.Y = Convert.ToDouble(textBoxY.Text);
            this.Dispose();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
