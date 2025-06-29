using System.Drawing;
using System.IO;
using System.Windows.Forms;
using RestaurantApp.Entities;

namespace RestaurantApp.UI
{
    public partial class DishForm : Form
    {
        private readonly Dish _dish;

        public DishForm(Dish selectedDish)
        {
            _dish = selectedDish;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = _dish.Name;
            this.Width = 400;
            this.Height = 300;

            var nameLabel = new Label { Text = $"Название: {_dish.Name}", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            var priceLabel = new Label { Text = $"Цена: {_dish.Price} руб.", Location = new System.Drawing.Point(20, 50), AutoSize = true };
            var categoryLabel = new Label { Text = $"Категория: {_dish.Category}", Location = new System.Drawing.Point(20, 80), AutoSize = true };
            var descriptionLabel = new Label { Text = $"Описание: {_dish.Description}", Location = new System.Drawing.Point(20, 110), AutoSize = true };
            var weightLabel = new Label { Text = $"Вес: {_dish.Weight} г", Location = new System.Drawing.Point(20, 140), AutoSize = true };
            var compositionLabel = new Label { Text = $"Состав: {_dish.Composition}", Location = new System.Drawing.Point(20, 170), AutoSize = true };
            // добавление картнинки, перед началом откоректируй расположение жлемента 
            // Как работает, я добавил папку с ИМЕНЕМ "Picure" (обяхательно имееено каое название), в класс Dish в ImagePath, нужно добавить 
            // имя картник, допустим будет "Pasta.jpg" (она разрешениея 300 на 300). Т.Е "Picture" Название не меняем, а если меняем то и меняй здесь название папки
            var ImagePB = new PictureBox() { SizeMode = PictureBoxSizeMode.Zoom, Location = new System.Drawing.Point(20, 170) };
            string imagePath = Path.Combine(Application.StartupPath, "..", "..", "..", "Picture", (string)_dish.ImagePath);
            imagePath = Path.GetFullPath(imagePath);
            ImagePB.Image = Image.FromFile(imagePath);

            var closeButton = new Button { Text = "Закрыть", Location = new System.Drawing.Point(20, 210) };
            closeButton.Click += (s, e) => Close();

            Controls.AddRange(new Control[]
            {
                nameLabel,
                priceLabel,
                categoryLabel,
                descriptionLabel,
                weightLabel,
                compositionLabel,
                closeButton
            });
        }
    }
}