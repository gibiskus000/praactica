using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp.Entities
{
    public class Order : IDomainObject
    {
        public int Id { get; set; }
        public string Type { get; set; } = "Самовывоз"; // "Доставка", "Столик"
        public List<Dish> Dishes { get; set; } = new List<Dish>();
        public string Status { get; set; } = "Создан";
        public string PaymentStatus { get; set; } = "Не оплачен";
        public string PaymentType { get; set; } = "";
        public string ClientName { get; set; } = "";
        public string ClientPhone { get; set; } = "";
        public string DeliveryAddress { get; set; } = "";
        public string AssignedTo { get; set; } = ""; // Имя курьера / официанта
        public DateTime Date { get; } = DateTime.Now;
       
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        // --- Новое свойство ---
        public TimeSpan EstimatedReadyTime { get; set; } = TimeSpan.Zero;
        public bool IsPaid => PaymentStatus == "Оплачен";

        public decimal TotalPrice => Dishes?.Sum(d => d.Price) ?? 0m;
    }
}