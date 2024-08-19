using HotelManagementSystem.Model.Entity;

namespace HotelManagementSystem.Models.Entity
{
    public class RequestPasswordReset : BaseEntity
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string ResetCode { get; set; } 
        public DateTime RequestedAt { get; set; } 
        public bool IsUsed { get; set; } 
        public DateTime UsedAt { get; set; } 
    }
}
