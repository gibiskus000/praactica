using System.Windows.Forms;

namespace RestaurantApp.UI
{
    public partial class EditProfileForm : Form
    {
        public EditProfileForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Редактировать профиль";
            this.Width = 400;
            this.Height = 300;

            var nameLabel = new Label { Text = "Имя", Location = new System.Drawing.Point(20, 20) };
            var nameBox = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200 };

            var phoneLabel = new Label { Text = "Телефон", Location = new System.Drawing.Point(20, 60) };
            var phoneBox = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 200 };

            var addressLabel = new Label { Text = "Адрес", Location = new System.Drawing.Point(20, 100) };
            var addressBox = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200 };

            var saveBtn = new Button { Text = "Сохранить", Location = new System.Drawing.Point(120, 140) };
            saveBtn.Click += (s, e) =>
            {
                MessageBox.Show("Профиль сохранён");
                this.Close();
            };

            Controls.AddRange(new Control[]
            {
                nameLabel, nameBox,
                phoneLabel, phoneBox,
                addressLabel, addressBox,
                saveBtn
            });
        }
    }
}