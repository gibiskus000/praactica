using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RestaurantApp.UI
{
    public partial class ChefPanel : Panel
    {
        private readonly ListBox _ordersList = new ListBox();
        private readonly ListBox _notReadyList = new ListBox();
        private readonly ListBox _readyList = new ListBox();

        private List<Order> Orders { get; } = new List<Order>
        {
            new Order
            {
                Id = 101,
                Dishes = new List<Dish>
                {
                    new Dish { Id = 1, Name = "Борщ", Price = 150 },
                    new Dish { Id = 2, Name = "Пирожки", Price = 50 }
                }
            },
            new Order
            {
                Id = 102,
                Dishes = new List<Dish>
                {
                    new Dish { Id = 3, Name = "Оливье", Price = 100 },
                    new Dish { Id = 4, Name = "Шашлык", Price = 200 }
                }
            }
        };

        public ChefPanel()
        {
            Dock = DockStyle.Fill;
            InitializeUI();
        }

        private void InitializeUI()
        {
            var ordersLabel = new Label { Text = "Активные заказы", Location = new System.Drawing.Point(20, 20) };
            _ordersList.Location = new System.Drawing.Point(20, 40);
            _ordersList.Width = 150;
            _ordersList.Height = 200;
            foreach (var order in Orders)
            {
                _ordersList.Items.Add($"Заказ #{order.Id}");
            }

            var dishesLabel = new Label { Text = "Не готовые блюда", Location = new System.Drawing.Point(200, 20) };
            _notReadyList.Location = new System.Drawing.Point(200, 40);
            _notReadyList.Width = 200;
            _notReadyList.Height = 200;

            var readyLabel = new Label { Text = "Готовые блюда", Location = new System.Drawing.Point(420, 20) };
            _readyList.Location = new System.Drawing.Point(420, 40);
            _readyList.Width = 200;
            _readyList.Height = 200;

            var moveBtn = new Button
            {
                Text = "Отметить как готовое",
                Location = new System.Drawing.Point(200, 250)
            };
            moveBtn.Click += OnMoveToReady;

            _ordersList.SelectedIndexChanged += OnOrderSelected;

            Controls.Add(ordersLabel);
            Controls.Add(_ordersList);
            Controls.Add(dishesLabel);
            Controls.Add(_notReadyList);
            Controls.Add(readyLabel);
            Controls.Add(_readyList);
            Controls.Add(moveBtn);

            LoadOrderDishes(Orders[0]);
        }

        private void OnOrderSelected(object sender, EventArgs e)
        {
            if (_ordersList.SelectedIndex >= 0)
            {
                int selectedIndex = _ordersList.SelectedIndex;
                var selectedOrder = Orders[selectedIndex];
                LoadOrderDishes(selectedOrder);
            }
        }

        private void LoadOrderDishes(Order order)
        {
            _notReadyList.Items.Clear();
            _readyList.Items.Clear();

            foreach (var dish in order.Dishes)
            {
                _notReadyList.Items.Add($"{dish.Name} - Не готов");
            }
        }

        private void OnMoveToReady(object sender, EventArgs e)
        {
            if (_notReadyList.SelectedItem != null)
            {
                string selected = _notReadyList.SelectedItem.ToString();
                _notReadyList.Items.Remove(selected);
                _readyList.Items.Add(selected.Replace(" - Не готов", " - Готов"));
            }
        }
    }
}