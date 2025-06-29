using RestaurantApp.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantApp.UI
{
    public class ManagerPanel : Panel
    {
        public ManagerPanel()
        {
            Dock = DockStyle.Fill;

            // Создаём список сотрудников
            var employees = new List<Employee>
        {
            new Manager { Id = 1, Name = "Алексей", Login = "manager", Effect = 2, isEfect = false },
            new Chef { Id = 2, Name = "Иван", Login = "chef", Effect = 3, isEfect = true }
        };

            // Сортируем по убыванию Effect
            var sortedEmployees = employees.OrderByDescending(e => e.Effect).ToList();

            // Создаём DataGridView
            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                DataSource = sortedEmployees
            };

            // Добавляем колонки вручную

            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                ReadOnly = true
            });

            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Имя"
            });

            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Login",
                HeaderText = "Логин"
            });

            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Effect",
                HeaderText = "Effect"
            });

            grid.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "isEfect",
                HeaderText = "Премия",
                TrueValue = true,
                FalseValue = false
            });

            // Кнопка регистрации сотрудника
            var registerBtn = new Button
            {
                Text = "Зарегистрировать сотрудника",
                Dock = DockStyle.Bottom
            };
            registerBtn.Click += (s, e) => new RegisterEmployeeForm().ShowDialog();

            // Добавляем контролы на панель
            Controls.Add(grid);
            Controls.Add(registerBtn);
        }
    }

}