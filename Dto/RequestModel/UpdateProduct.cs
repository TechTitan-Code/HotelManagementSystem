using HotelManagementSystem.Model.Entity;

namespace HotelManagementSystem.Dto.RequestModel
{
    public class UpdateProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Product Product { get; set; }
        public string Items { get; set; }
        public double Price { get; set; }
    }
}
