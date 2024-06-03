using HotelManagementSystem.Model.Entity;
using HotelManagementSystem.Model.Entity.Enum;

namespace HotelManagementSystem.Dto
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public RoomName RoomName { get; set; }
        public int RoomNumber { get; set; }
        // public int RoomCount { get; set; }
        public RoomType RoomType { get; set; }
        public BedType BedType { get; set; }
        public int MaxOccupancy { get; set; }
        public decimal RoomRate { get; set; }
        public RoomStatus RoomStatus { get; set; }
       // public Amenity Amenity { get; set; }
        public bool Availability { get; set; }

    }


}
