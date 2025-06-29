namespace RestaurantApp.Entities
{
    public class Dish : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
        public string Category { get; set; } = "";
        public string Composition { get; set; } = "";
        public int Weight { get; set; }
        public string ImagePath { get; set; } = "";
    }
}