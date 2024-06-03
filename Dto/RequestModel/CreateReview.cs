using HotelManagementSystem.Model.Entity.Enum;

namespace HotelManagementSystem.Dto.RequestModel
{
    public class CreateReview
    {
        public string Comment { get; set; }
        public Review Rating { get; set; }
    }
}
