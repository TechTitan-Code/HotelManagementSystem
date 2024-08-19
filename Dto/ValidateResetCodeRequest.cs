using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Dto
{
    public class ValidateResetCodeRequest
    {
        [Required]
        public string ResetCode { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        public string UserId { get; set; }
        public DateTime RequestedAt { get; set; }
        public bool IsUsed { get; set; }
        public DateTime UsedAt { get; set; }
    }
}
