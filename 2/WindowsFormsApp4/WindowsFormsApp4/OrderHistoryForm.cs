using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantApp.UI
{
    public partial class OrderHistoryForm : Form
    {
        private readonly List<Order> _orders;
        private readonly Timer _refreshTimer;

        private DataGridView _ordersGrid;

        public OrderHistoryForm(List<Order> orders)
        {
            _orders = orders;

            InitializeComponent();

            _refreshTimer = new Timer();
            _refreshTimer.Interval = 2000; // 2 секунды
            _refreshTimer.Tick += (s, e) => RefreshGrid();
            _refreshTimer.Start();
        }

        private void InitializeComponent()
        {
            this.Text = "История заказов";
            this.Width = 600;
            this.Height = 400;

            _ordersGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };

            _ordersGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });

            _ordersGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Блюда",
                DataPropertyName = "DishesDescription",
                Width = 200
            });

            _ordersGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Статус",
                DataPropertyName = "Status",
                Width = 120
            });

            _ordersGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Создан",
                DataPropertyName = "CreatedAt",
                Width = 150
            });

            Controls.Add(_ordersGrid);
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            foreach (var order in _orders)
            {
                if (order.Status != "Готов" && (DateTime.Now - order.CreatedAt).TotalSeconds >= 15)
                {
                    order.Status = "Готов";
                    order.CompletedAt = DateTime.Now;
                }
            }

            _ordersGrid.DataSource = null;
            _ordersGrid.DataSource = _orders.Select(o => new
            {
                o.Id,
                DishesDescription = string.Join(", ", o.Dishes.Select(d => d.Name)),
                o.Status,
                CreatedAt = o.CreatedAt.ToString("HH:mm:ss")
            }).ToList();
        }
    }
}

