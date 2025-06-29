using System.Windows.Forms;

namespace RestaurantApp.UI
{
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Профиль";
            this.Width = 500;
            this.Height = 400;

            var nameLabel = new Label { Text = "Имя: Иван Петров", Location = new System.Drawing.Point(20, 20) };
            var phoneLabel = new Label { Text = "Телефон: +79123456789", Location = new System.Drawing.Point(20, 50) };
            var addressLabel = new Label { Text = "Адрес: ул. Ленина, д. 1", Location = new System.Drawing.Point(20, 80) };

            var ordersList = new ListBox
            {
                Location = new System.Drawing.Point(20, 120),
                Width = 400,
                Height = 200
            };
            ordersList.Items.Add("Заказ #101 - Готовится");
            ordersList.Items.Add("Заказ #102 - Оплачен");

            var editBtn = new Button
            {
                Text = "Редактировать профиль",
                Location = new System.Drawing.Point(20, 320)
            };
            editBtn.Click += (s, e) => new EditProfileForm().ShowDialog();

            Controls.Add(nameLabel);
            Controls.Add(phoneLabel);
            Controls.Add(addressLabel);
            Controls.Add(ordersList);
            Controls.Add(editBtn);
        }
    }
}