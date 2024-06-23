using HotelManagementSystem.Model.Entity;
using HotelManagementSystem.Model.Entity.Enum;

namespace HotelManagementSystem.Dto.RequestModel
{
    public class CreateBooking
    {
        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public RoomStatus Status { get; set; }
        public decimal TotalCost { get; set; }
        public Guid RoomId { get; set; }
        public ICollection<RoomDto> Rooms { get; set; } = new List<RoomDto>();

        public class RoomDto
        {
            public Guid RoomId { get; set; }
        }
    }
}


