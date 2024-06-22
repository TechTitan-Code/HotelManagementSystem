using HotelManagementSystem.Model.Entity.Enum;

namespace HotelManagementSystem.Model.Entity
{
    public class Booking : BaseEntity
    {
        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalCost { get; set; } = 0;
        public Guid RoomId { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }

}
