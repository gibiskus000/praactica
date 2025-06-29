using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApp.Data
{
    public static class DataConverter
    {
        public static async Task<List<Dish>> LoadMenuAsync(IProgress<int> progress = null)
        {
            await Task.Delay(500); // имитация асинхронной загрузки
            var menu = new List<Dish>
            {
                new Dish { Id = 1, Name = "Борщ", Price = 150, Category = "Первое" },
                new Dish { Id = 2, Name = "Пирожки", Price = 50, Category = "Закуска" }
            };
            progress?.Report(100);
            return menu;
        }

        public static async Task SaveMenuAsync(List<Dish> dishes)
        {
            await Task.Delay(500);
        }

        public static async Task<List<Employee>> LoadEmployeesAsync()
        {
            await Task.Delay(500);
            return new List<Employee>();
        }

        public static async Task<List<Client>> LoadClientsAsync()
        {
            await Task.Delay(500);
            return new List<Client>();
        }
    }
}