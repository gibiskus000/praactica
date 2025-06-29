using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RestaurantApp.UI
{
    public partial class CourierPanel : Panel
    {
        private readonly List<int> _activeOrders = new List<int> { 101, 102 };
        private readonly List<int> _takenOrders = new List<int>();

        public CourierPanel()
        {
            Dock = DockStyle.Fill;
            InitializeMap();
            InitializeOrders();
        }

        private void InitializeMap()
        {
            var mapPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray
            };

            var restaurant = new PictureBox
            {
                Size = new Size(20, 20),
                BackColor = Color.Red,
                Location = new Point(100, 100)
            };

            var orderPoint = new PictureBox
            {
                Size = new Size(20, 20),
                BackColor = Color.Blue,
                Location = new Point(300, 300)
            };

            var takeBtn = new Button
            {
                Text = "Взять заказ",
                Dock = DockStyle.Bottom
            };
            takeBtn.Click += OnTakeOrder;

            mapPanel.Controls.Add(restaurant);
            mapPanel.Controls.Add(orderPoint);

            Controls.Add(mapPanel);
            Controls.Add(takeBtn);
        }

        private void InitializeOrders()
        {
            var ordersList = new ListBox
            {
                Dock = DockStyle.Bottom,
                Height = 100
            };
            foreach (var id in _activeOrders)
            {
                ordersList.Items.Add($"Заказ #{id}");
            }

            Controls.Add(ordersList);
        }

        private void OnTakeOrder(object sender, EventArgs e)
        {
            if (_activeOrders.Count > 0)
            {
                int selectedOrder = _activeOrders[0];
                _activeOrders.RemoveAt(0);
                _takenOrders.Add(selectedOrder);

                MessageBox.Show("Заказ взят");
            }
        }
    }
}