using HotelManagementSystem.Dto.ResponseModel;
using HotelManagementSystem.Model.Entity;

namespace HotelManagementSystem.Dto
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Product Product { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
   
}
