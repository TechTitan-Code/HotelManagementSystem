namespace HotelManagementSystem.Model.Entity
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public decimal TotalAmount { get; set; }
    }

}
