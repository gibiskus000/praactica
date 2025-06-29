using System.Windows.Forms;

namespace RestaurantApp.UI
{
    public partial class MainForm : Form
    {
        private string UserRole { get; }

        public MainForm(string role)
        {
            UserRole = role;
            InitializeComponent();
            LoadInterface();
        }

        private void InitializeComponent()
        {
            this.Text = $"Ресторан - {UserRole}";
            this.Width = 800;
            this.Height = 600;
        }

        private void LoadInterface()
        {
            switch (UserRole.ToLower())
            {
                case "client":
                    Controls.Add(new ClientPanel());
                    break;
                case "chef":
                    Controls.Add(new ChefPanel());
                    break;
                case "waiter":
                    Controls.Add(new WaiterPanel());
                    break;
                case "courier":
                    Controls.Add(new CourierPanel());
                    break;
                case "manager":
                    Controls.Add(new ManagerPanel());
                    break;
                default:
                    MessageBox.Show("Неизвестная роль");
                    this.Close();
                    break;
            }
        }
    }
}