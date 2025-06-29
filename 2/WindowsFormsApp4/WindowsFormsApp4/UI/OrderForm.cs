using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantApp.UI
{
    public partial class OrderForm : Form
    {
        private readonly string _userType;
        private readonly List<Dish> _cart;

        // ✅ Делаем deliveryRadio и pickupRadio полями класса
        private RadioButton deliveryRadio;
        private RadioButton pickupRadio;
        private ComboBox _assignedToBox = new ComboBox();

        public OrderForm(string userType, List<Dish> cart)
        {
            _userType = userType;
            _cart = cart ?? new List<Dish>();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Оформление заказа";
            this.Width = 600;
            this.Height = 500;

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoScroll = true
            };

            foreach (var dish in _cart.Distinct())
            {
                int count = _cart.Count(d => d.Id == dish.Id);
                var label = new Label
                {
                    Text = $"{dish.Name} x {count} — {dish.Price * count} руб.",
                    Width = 500,
                    Margin = new Padding(5),
                    AutoSize = true
                };
                flow.Controls.Add(label);
            }

            // --- Переключатель: доставка / самовывоз ---
            deliveryRadio = new RadioButton { Text = "Доставка", Location = new System.Drawing.Point(20, 200) };
            pickupRadio = new RadioButton { Text = "Самовывоз", Checked = true, Location = new System.Drawing.Point(120, 200) };

            // --- Панель адреса (для доставки) ---
            var addressPanel = new Panel { Dock = DockStyle.Top, Height = 70, Visible = false };
            var addressLabel = new Label { Text = "Адрес доставки:", Location = new System.Drawing.Point(20, 10) };
            var addressBox = new TextBox { Location = new System.Drawing.Point(150, 10), Width = 250 };
            var nameLabel = new Label { Text = "Имя получателя:", Location = new System.Drawing.Point(20, 40) };
            var nameBox = new TextBox { Location = new System.Drawing.Point(150, 40), Width = 250 };

            addressPanel.Controls.Add(addressLabel);
            addressPanel.Controls.Add(addressBox);
            addressPanel.Controls.Add(nameLabel);
            addressPanel.Controls.Add(nameBox);

            // --- Обновление полей при переключении ---
            Action updateFields = () =>
            {
                bool isDelivery = deliveryRadio.Checked;

                addressPanel.Visible = isDelivery;
                if (isDelivery)
                {
                    _assignedToBox.Items.Clear();
                    _assignedToBox.Items.AddRange(new object[]
                    {
                        "Курьер - Алексей",
                        "Курьер - Максим",
                        "Курьер - Дмитрий"
                    });
                    _assignedToBox.SelectedIndex = 0;
                }
                else
                {
                    _assignedToBox.Items.Clear();
                    _assignedToBox.Items.AddRange(new object[]
                    {
                        "Официант - Иван",
                        "Официант - Сергей",
                        "Официант - Евгений"
                    });
                    _assignedToBox.SelectedIndex = 0;
                }
            };

            deliveryRadio.CheckedChanged += (s, e) => updateFields();
            pickupRadio.CheckedChanged += (s, e) => updateFields();

            updateFields(); // ❗ первый вызов для правильного отображения

            // --- Кто принесёт / доставит ---
            var assignedToLabel = new Label
            {
                Text = "Кто принесёт:",
                Location = new System.Drawing.Point(20, 260),
                AutoSize = true
            };

            _assignedToBox.Location = new System.Drawing.Point(150, 260);
            _assignedToBox.Width = 200;
            _assignedToBox.DropDownStyle = ComboBoxStyle.DropDownList;

            // --- Подтверждение заказа ---
            var confirmBtn = new Button
            {
                Text = "Подтвердить заказ",
                Location = new System.Drawing.Point(20, 300)
            };
            confirmBtn.Click += OnConfirmOrder;

            Controls.AddRange(new Control[]
            {
                flow,
                deliveryRadio,
                pickupRadio,
                addressPanel,
                assignedToLabel,
                _assignedToBox,
                confirmBtn
            });
        }

        private void OnConfirmOrder(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одно блюдо");
                return;
            }

            // 👉 Запоминаем, что выбрал пользователь
            DeliveryMethod = deliveryRadio.Checked ? "Доставка" : "Самовывоз";
            AssignedTo = _assignedToBox.SelectedItem?.ToString() ?? "";

            string message = $"Заказ оформлен\nТип: {DeliveryMethod}\n{AssignedTo}\n";
            message += "Ваш заказ будет готов через 15 секунд.";

            MessageBox.Show(message);
            this.DialogResult = DialogResult.OK; // сигнал для вызывающей формы
            this.Close();
        }

        // 👇 Эти данные получим после оформления заказа
        public string DeliveryMethod { get; private set; } = "Самовывоз";
        public string AssignedTo { get; private set; } = "";

    }
}