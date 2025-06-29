using RestaurantApp.Entities;
using System;
using System.Windows.Forms;

namespace RestaurantApp.UI
{
    public partial class PaymentForm : Form
    {
        private readonly Order _order;

        public PaymentForm(Order order)
        {
            _order = order;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Оплата заказа";
            this.Width = 400;
            this.Height = 300;

            var totalLabel = new Label
            {
                Text = $"Общая сумма: {_order.TotalPrice} руб.",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };

            var cashBtn = new Button
            {
                Text = "Наличными",
                Location = new System.Drawing.Point(20, 60)
            };
            cashBtn.Click += OnPayCash;

            var cardBtn = new Button
            {
                Text = "Картой",
                Location = new System.Drawing.Point(150, 60)
            };
            cardBtn.Click += OnPayCard;

            Controls.Add(totalLabel);
            Controls.Add(cashBtn);
            Controls.Add(cardBtn);
        }

        private void OnPayCash(object sender, EventArgs e)
        {
            _order.PaymentStatus = "Оплачен наличными";
            MessageBox.Show("Заказ успешно оплачен наличными.");
            this.Close();
        }

        private void OnPayCard(object sender, EventArgs e)
        {
            _order.PaymentStatus = "Оплачен картой";
            MessageBox.Show("Заказ успешно оплачен картой.");
            this.Close();
        }
    }
}