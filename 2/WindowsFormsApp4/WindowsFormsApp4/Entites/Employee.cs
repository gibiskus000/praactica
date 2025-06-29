namespace RestaurantApp.Entities
{
    public abstract class Employee : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public double Effect { get; set; } = 0;
        public bool isEfect { get; set; } = false;
    }

    public class Chef : Employee { }
    public class Waiter : Employee { }
    public class Courier : Employee { }
    public class Manager : Employee { }
}