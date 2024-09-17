using HotelManagementSystem.Model.Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Dto.RequestModel
{
    public class InitializePaymentRequestDto
    {
        public string Email { get; set; }
        public string UserId { get; set; }
        public Guid BookingId { get; set; }
    }
}