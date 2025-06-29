    using System;
    using System.Windows.Forms;

    namespace RestaurantApp
    {
        public partial class LoginForm : Form
        {
            private string _generatedCode = "";
            private readonly TextBox _codeBox = new TextBox(); // Поле ввода кода
            private readonly ProgressBar _progressBar = new ProgressBar();

            public LoginForm()
            {
                InitializeComponent();
            }

            private void InitializeComponent()
            {
                this.Text = "Вход в систему";
                this.Width = 300;
                this.Height = 300;

                // --- Переключатель ---
                var userLabel = new Label { Text = "Тип пользователя", Location = new System.Drawing.Point(20, 10) };
                var clientRadio = new RadioButton { Text = "Клиент", Location = new System.Drawing.Point(20, 30), Checked = true };
                var employeeRadio = new RadioButton { Text = "Сотрудник", Location = new System.Drawing.Point(20, 50) };

            // --- Поля клиента ---
            var phoneLabel = new Label { Text = "Номер телефона", Location = new System.Drawing.Point(20, 80) };
            var phoneBox = new TextBox { Location = new System.Drawing.Point(20, 100), Width = 150 };

            var sendCodeBtn = new Button { Text = "Прислать код", Location = new System.Drawing.Point(20, 130) };

            // Убрано Visible = false, чтобы поле кода было видно сразу для клиента
            var codeLabel = new Label { Text = "Введите код", Location = new System.Drawing.Point(20, 160) };
            _codeBox.Location = new System.Drawing.Point(20, 180);
            _codeBox.MaxLength = 5;
            _codeBox.Width = 60;



            // --- Поля сотрудника (скрыты по умолчанию) ---
            var loginLabel = new Label { Text = "Логин", Visible = false, Location = new System.Drawing.Point(20, 80) };
                var loginBox = new TextBox { Location = new System.Drawing.Point(20, 100), Width = 150, Visible = false };

                var passLabel = new Label { Text = "Пароль", Visible = false, Location = new System.Drawing.Point(20, 120) };
                var passBox = new TextBox { UseSystemPasswordChar = true, Location = new System.Drawing.Point(20, 140), Width = 150, Visible = false };

                var submitBtn = new Button { Text = "Войти", Location = new System.Drawing.Point(20, 200) };
                var infoLabel = new Label { Location = new System.Drawing.Point(20, 230), AutoSize = true };

            // --- Скрытие/показ полей по роли ---
            Action<bool> toggleFields = isEmployee =>
            {
                phoneLabel.Visible = !isEmployee;
                phoneBox.Visible = !isEmployee;
                sendCodeBtn.Visible = !isEmployee;
                codeLabel.Visible = !isEmployee;  // Теперь корректно управляется
                _codeBox.Visible = !isEmployee;   // Теперь корректно управляется

                loginLabel.Visible = isEmployee;
                loginBox.Visible = isEmployee;
                passLabel.Visible = isEmployee;
                passBox.Visible = isEmployee;
            };

            employeeRadio.CheckedChanged += (s, e) => toggleFields(employeeRadio.Checked);

                // --- Прислать код ---
                sendCodeBtn.Click += (s, e) =>
                {
                    _generatedCode = GenerateCode();

                    var codeForm = new Form
                    {
                        Text = "Код подтверждения",
                        StartPosition = FormStartPosition.Manual,
                        Size = new System.Drawing.Size(200, 100),
                        TopMost = true,
                        ShowInTaskbar = false
                    };

                    var label = new Label
                    {
                        Text = $"Код: {_generatedCode}",
                        Font = new System.Drawing.Font("Consolas", 12),
                        AutoSize = true,
                        Location = new System.Drawing.Point(50, 30)
                    };

                    codeForm.Controls.Add(label);
                    codeForm.Show();
                };

                // --- Ввод кода ---
                _codeBox.KeyPress += (s, e) =>
                {
                    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                };

                _codeBox.TextChanged += (s, e) =>
                {
                    if (_codeBox.Text.Length == 5 && _codeBox.Text == _generatedCode)
                    {
                        infoLabel.Text = "Код верен!";
                    }
                    else
                    {
                        infoLabel.Text = "";
                    }
                };

          

                // --- Обработка входа ---
                submitBtn.Click += (s, e) =>
                {
                    if (employeeRadio.Checked)
                    {
                        if ((loginBox.Text == "chef" && passBox.Text == "Chef123!") ||
                            (loginBox.Text == "manager" && passBox.Text == "ManagerPass!") ||
                            (loginBox.Text == "waiter" && passBox.Text == "WaiterPass!") ||
                            (loginBox.Text == "courier" && passBox.Text == "CourierPass!"))
                        {
                            this.Hide();
                            new UI.MainForm(loginBox.Text).Show();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка входа!");
                        }
                    }
                    else
                    {
                        string input = phoneBox.Text.Trim();
                        string digitsOnly = "";

                        foreach (char c in input)
                        {
                            if (char.IsDigit(c)) digitsOnly += c;
                        }

                        if (digitsOnly.StartsWith("7") || digitsOnly.StartsWith("8"))
                        {
                            digitsOnly = digitsOnly.Substring(1);
                        }

                        if (digitsOnly.Length != 10)
                        {
                            MessageBox.Show("Введите корректный номер телефона.");
                            return;
                        }

                        if (_codeBox.Text != _generatedCode || _codeBox.Text.Length < 5)
                        {
                            MessageBox.Show("Введите полученный код");
                            return;
                        }

                        this.Hide();
                        new UI.MainForm("Client").Show();
                    }
                };

                // --- Добавление контролов на форму ---
                Controls.AddRange(new Control[]
                {
                    userLabel, clientRadio, employeeRadio,
                    phoneLabel, phoneBox, sendCodeBtn,
                    codeLabel, _codeBox,  
                    loginLabel, loginBox, passLabel, passBox,
                    submitBtn, infoLabel, _progressBar
                });

                _progressBar.Location = new System.Drawing.Point(20, 260);
                _progressBar.Width = 200;
                _progressBar.Minimum = 0;
                _progressBar.Maximum = 100;
                _progressBar.Visible = false;
            }

            private string GenerateCode()
            {
                var random = new Random();
                int code = random.Next(10000, 99999); // 5-значный код
                return code.ToString();
            }
        }

    }