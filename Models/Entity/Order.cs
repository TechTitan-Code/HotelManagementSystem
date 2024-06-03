namespace HotelManagementSystem.Model.Entity
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } 
        public Product Product { get; set; } 
        public decimal TotalAmount { get; set; }
    }
}
