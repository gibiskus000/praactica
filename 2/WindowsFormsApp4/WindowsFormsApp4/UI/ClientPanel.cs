using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantApp.UI
{
    public partial class ClientPanel : Panel
    {
        private readonly List<Dish> _cart = new List<Dish>();
        private readonly List<Order> _orderHistory = new List<Order>();
        private readonly ListBox _cartListBox = new ListBox();
        private readonly Label _totalLabel = new Label();
        private readonly Label _statusLabel = new Label();
        private Timer _orderTimer;

        public ClientPanel()
        {
            Dock = DockStyle.Fill;
            LoadMenu();
            LoadCart();

            _statusLabel.Text = "";
            _statusLabel.Dock = DockStyle.Bottom;
            _statusLabel.Height = 30;
            _statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(_statusLabel);
        }

        private void LoadMenu()
        {
            var flowMenu = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                Height = 300
            };

            foreach (var dish in SampleMenu())
            {
                var itemPanel = new FlowLayoutPanel
                {
                    Width = 220,
                    Height = 50,
                    FlowDirection = FlowDirection.LeftToRight,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(5)
                };

                var pic = new PictureBox
                {
                    Width = 40,
                    Height = 40,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = LoadDishImage(dish.ImagePath),
                    Margin = new Padding(5)
                };

                var label = new Label
                {
                    Text = $"{dish.Name} - {dish.Price} руб.",
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(5, 10, 0, 0)
                };

                itemPanel.Controls.Add(pic);
                itemPanel.Controls.Add(label);

                itemPanel.Click += (s, e) => AddDishToCart(dish);
                pic.Click += (s, e) => AddDishToCart(dish);
                label.Click += (s, e) => AddDishToCart(dish);

                flowMenu.Controls.Add(itemPanel);
            }

            var orderBtn = new Button
            {
                Text = "Сделать заказ",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            orderBtn.Click += OnMakeOrder;

            var historyBtn = new Button
            {
                Text = "История заказов",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            historyBtn.Click += (s, e) =>
            {
                var historyForm = new OrderHistoryForm(_orderHistory);
                historyForm.ShowDialog();
            };

            Controls.Add(flowMenu);
            Controls.Add(historyBtn);
            Controls.Add(orderBtn);
        }

        private Image LoadDishImage(string relativeImagePath)
        {
            try
            {
                string imagePath = Path.Combine(Application.StartupPath, "..", "..", "Picture", relativeImagePath);
                imagePath = Path.GetFullPath(imagePath);

                if (!File.Exists(imagePath))
                    return null;

                using (var img = Image.FromFile(imagePath))
                {
                    var thumb = img.GetThumbnailImage(40, 40, () => false, IntPtr.Zero);
                    return thumb;
                }
            }
            catch
            {
                return null;
            }
        }

        private void AddDishToCart(Dish dish)
        {
            _cart.Add(dish);
            UpdateCart();
        }

        private void LoadCart()
        {
            var cartPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 150,
                Padding = new Padding(10)
            };

            _cartListBox.Dock = DockStyle.Top;
            _cartListBox.Height = 80;

            _totalLabel.Text = "Общая сумма: 0 руб.";
            _totalLabel.AutoSize = true;
            _totalLabel.Location = new Point(20, 90);
            _totalLabel.Font = new Font(_totalLabel.Font, FontStyle.Bold);

            cartPanel.Controls.Add(_cartListBox);
            cartPanel.Controls.Add(_totalLabel);

            Controls.Add(cartPanel);
        }

        private void UpdateCart()
        {
            _cartListBox.Items.Clear();

            var grouped = _cart.GroupBy(d => d.Name)
                               .Select(g => new
                               {
                                   Name = g.Key,
                                   Count = g.Count(),
                                   Price = g.First().Price
                               });

            foreach (var item in grouped)
            {
                _cartListBox.Items.Add($"{item.Name} x{item.Count} — {item.Price * item.Count} руб.");
            }

            decimal total = _cart.Sum(d => d.Price);
            _totalLabel.Text = $"Общая сумма: {total} руб.";
        }

        private async void OnMakeOrder(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одно блюдо");
                return;
            }

            var orderForm = new OrderForm("Client", _cart);
            var result = orderForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                var order = new Order
                {
                    Id = _orderHistory.Count + 1,
                    Dishes = new List<Dish>(_cart),
                    Status = "В процессе приготовления",
                    CreatedAt = DateTime.Now,
                    Type = orderForm.DeliveryMethod,
                    AssignedTo = orderForm.AssignedTo,
                    PaymentStatus = "Не оплачен",
                    ClientName = "Имя клиента",
                    DeliveryAddress = orderForm.DeliveryMethod == "Доставка" ? "Адрес доставки" : ""
                };

                _orderHistory.Add(order);

                _cart.Clear();
                UpdateCart();

                _statusLabel.Text = "Заказ принят. Готовим...";

                // ⏱ Запуск асинхронного обновления статуса
                await SimulateOrderProgressAsync(order);
            }
        }




        private List<Dish> SampleMenu()
        {
            return new List<Dish>
            {
                new Dish { Name = "Борщ", Price = 150 , ImagePath = "Mushroom.jpg"},
                new Dish { Name = "Пирожки", Price = 50, ImagePath = "Pirojok.jpg" },
                new Dish { Name = "Оливье", Price = 100 , ImagePath = "olive.jpg"},
                new Dish { Name = "Шашлык", Price = 200 , ImagePath = "shahslik.jpg"}
            };
        }
        // В самом конце файла, перед закрытием класса
        private async System.Threading.Tasks.Task SimulateOrderProgressAsync(Order order)
        {
            // Имитация приготовления
            await System.Threading.Tasks.Task.Delay(5000);
            order.Status = "Готов";
            _statusLabel.Text = "Заказ готов!";

            if (order.Type == "Доставка")
            {
                await System.Threading.Tasks.Task.Delay(5000);
                order.Status = "Доставлен";
                _statusLabel.Text = "Заказ доставлен!";
            }
            else if (order.Type == "Самовывоз")
            {
                _statusLabel.Text = "Заберите заказ в течение 15 минут.";
            }
        }

    }
}
