using HotelManagementSystem.Model.Entity;
using HotelManagementSystem.Model.Entity.Enum;

namespace HotelManagementSystem.Model.Entity
{
    public class CustomerReview : BaseEntity
    {
        public string Comment { get; set; }
        public Review Rating { get; set; }
    }
}
