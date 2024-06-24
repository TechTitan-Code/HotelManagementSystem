using HotelManagementSystem.Dto.ResponseModel;
using HotelManagementSystem.Model.Entity;
using HotelManagementSystem.Model.Entity.Enum;

namespace HotelManagementSystem.Dto
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public Product Products { get; set; }
        public decimal TotalAmount { get; set; }
    }


}
