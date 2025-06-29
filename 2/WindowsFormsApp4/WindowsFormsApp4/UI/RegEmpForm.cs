using RestaurantApp.Utils;
using System;
using System.Windows.Forms;

namespace RestaurantApp.UI
{
    public partial class RegisterEmployeeForm : Form
    {
        private readonly Random _random = new Random();

        public RegisterEmployeeForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Регистрация сотрудника";
            this.Width = 400;
            this.Height = 300;

            var typeCombo = new ComboBox
            {
                Items = { "Повар", "Официант", "Курьер", "Менеджер" },
                SelectedIndex = 0,
                Location = new System.Drawing.Point(150, 20),
                Width = 200
            };

            var nameLabel = new Label { Text = "Имя", Location = new System.Drawing.Point(20, 60) };
            var nameBox = new TextBox { Location = new System.Drawing.Point(150, 60), Width = 200 };

            var phoneLabel = new Label { Text = "Телефон", Location = new System.Drawing.Point(20, 100) };
            var phoneBox = new TextBox { Location = new System.Drawing.Point(150, 100), Width = 200 };

            var loginLabel = new Label { Text = "Логин", Location = new System.Drawing.Point(20, 140) };
            var loginBox = new TextBox { Location = new System.Drawing.Point(150, 140), Width = 200 };

            var passLabel = new Label { Text = "Пароль", Location = new System.Drawing.Point(20, 180) };
            var passBox = new TextBox { Location = new System.Drawing.Point(150, 180), Width = 200 };

            var generateBtn = new Button
            {
                Text = "Сгенерировать логин и пароль",
                Location = new System.Drawing.Point(20, 220)
            };
            generateBtn.Click += (s, e) =>
            {
                loginBox.Text = $"emp_{DateTime.Now.Ticks.ToString().Substring(5)}";
                passBox.Text = PasswordGenerator.Generate();
            };

            var registerBtn = new Button
            {
                Text = "Зарегистрировать",
                Location = new System.Drawing.Point(20, 260)
            };
            registerBtn.Click += (s, e) =>
            {
                MessageBox.Show("Сотрудник зарегистрирован");
            };

            Controls.AddRange(new Control[]
            {
                new Label { Text = "Тип сотрудника", Location = new System.Drawing.Point(20, 20) },
                typeCombo,
                nameLabel, nameBox,
                phoneLabel, phoneBox,
                loginLabel, loginBox,
                passLabel, passBox,
                generateBtn,
                registerBtn
            });
        }
    }
}