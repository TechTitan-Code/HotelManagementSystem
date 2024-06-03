using HotelManagementSystem.Model.Entity;

namespace HotelManagementSystem.Model.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Items { get; set; }
        public double Price { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
