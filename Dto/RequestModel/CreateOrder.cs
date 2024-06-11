using HotelManagementSystem.Model.Entity;

namespace HotelManagementSystem.Dto.RequestModel
{
    public class CreateOrder
    {
    
            public DateTime OrderDate { get; set; }
            public Product Product { get; set; }
            public decimal TotalAmount { get; set; }
            public List<ProductDto> Products { get; set; }
        

    }
}
