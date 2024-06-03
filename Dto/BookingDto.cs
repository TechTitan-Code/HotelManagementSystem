using HotelManagementSystem.Model.Entity;
using HotelManagementSystem.Model.Entity.Enum;

namespace HotelManagementSystem.Dto
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
        public RoomStatus Status { get; set; } = RoomStatus.Pending;
        public decimal TotalCost { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();

    }

    
}
