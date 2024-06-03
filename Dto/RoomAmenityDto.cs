using HotelManagementSystem.Model.Entity;

namespace HotelManagementSystem.Dto
{
    public class RoomAmenityDto
    {
        public int RoomId { get; set; }
        public int AmenityId { get; set; }
        public Room Room { get; set; }
        public Amenity Amenity { get; set; }
    }
}
