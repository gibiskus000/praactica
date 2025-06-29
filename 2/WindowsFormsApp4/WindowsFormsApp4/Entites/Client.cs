using System.Collections.Generic;

namespace RestaurantApp.Entities
{
    public class Client : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public List<int> Orders { get; } = new List<int>();
    }
}