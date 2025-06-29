using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApp.UI
{
    public partial class WaiterPanel : Panel
    {
        private readonly List<Order> _orders = new List<Order>();
        private readonly ListBox _ordersList = new ListBox();
        private readonly ListBox _notReadyList = new ListBox();
        private readonly ListBox _readyList = new ListBox();

        public WaiterPanel()
        {
            Dock = DockStyle.Fill;
            InitializeUI();
        }

        private void InitializeUI()
        {
            var tabControl = new TabControl { Dock = DockStyle.Fill };

            var menuTab = new TabPage("Меню");
            var ordersTab = new TabPage("Заказы");

            LoadMenu(menuTab);
            LoadOrders(ordersTab);

            tabControl.TabPages.Add(menuTab);
            tabControl.TabPages.Add(ordersTab);

            Controls.Add(tabControl);
        }

        // --- Метод загрузки меню ---
        private void LoadMenu(TabPage tabPage)
        {
            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoScroll = true
            };

            foreach (var dish in SampleMenu())
            {
                var btn = new Button
                {
                    Text = $"{dish.Name} - {dish.Price} руб.",
                    Width = 200
                };
                btn.Click += (s, e) => new DishForm(dish).ShowDialog();
                flow.Controls.Add(btn);
            }

            var orderBtn = new Button
            {
                Text = "Сделать заказ",
                Dock = DockStyle.Bottom
            };
            orderBtn.Click += OnMakeOrder;

            tabPage.Controls.Add(flow);
            tabPage.Controls.Add(orderBtn);
        }

        // --- Метод создания тестового меню ---
        private List<Dish> SampleMenu()
        {
            return new List<Dish>
            {
                new Dish { Name = "Борщ", Price = 150 },
                new Dish { Name = "Пирожки", Price = 50 },
                new Dish { Name = "Оливье", Price = 100 },
                new Dish { Name = "Шашлык", Price = 200 }
            };
        }

        // --- Обработка нажатия на "Сделать заказ" ---
        private void OnMakeOrder(object sender, EventArgs e)
        {
            var cart = new List<Dish>(SampleMenu());
            if (cart.Count == 0)
            {
                MessageBox.Show("Нет доступных блюд для заказа.");
                return;
            }

            new OrderForm("Waiter", cart).ShowDialog();
        }

        // --- Загрузка текущих заказов ---
        private void LoadOrders(TabPage tabPage)
        {
            var timer = new Timer { Interval = 5000 };
            timer.Tick += async (s, e) => await RefreshOrdersAsync();
            timer.Start();

            var ordersList = new ListBox { Dock = DockStyle.Top, Height = 150 };
            var dishesList = new ListBox { Dock = DockStyle.Top, Height = 150 };
            var payBtn = new Button { Text = "Оплатить заказ", Dock = DockStyle.Top };

            tabPage.Controls.Add(ordersList);
            tabPage.Controls.Add(dishesList);
            tabPage.Controls.Add(payBtn);
        }

        private async Task RefreshOrdersAsync()
        {
            // Здесь будет асинхронная загрузка из файла
            await Task.Delay(1000); // имитация
        }
    }
}