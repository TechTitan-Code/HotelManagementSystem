using HotelManagementSystem.Model.Entity;

namespace HotelManagementSystem.Dto.RequestModel
{
    public class UpdateOrder
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Product Product { get; set; } 
        public decimal TotalAmount { get; set; }

    }
}
