
using HotelManagementSystem.Dto.ResponseModel;
using HotelManagementSystem.Model.Entity.Enum;
using Microsoft.VisualBasic;

namespace HotelManagementSystem.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; } 
        public DateOnly DateOfBirth { get; set; }
        public string? Password { get; set; }
        public Gender Gender { get; set; }

       
    }

}
