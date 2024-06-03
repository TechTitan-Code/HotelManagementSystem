namespace HotelManagementSystem.Model.Entity
{
    public class Payment : BaseEntity
    {
        public int BookingId { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string? PaymentStatus { get; set; }
    }
}
