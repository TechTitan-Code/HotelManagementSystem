using HotelManagementSystem.Dto;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Dto.ResponseModel;
using HotelManagementSystem.Implementation.Interface;
using HotelManagementSystem.Model.Entity;
using Microsoft.EntityFrameworkCore;
namespace HotelManagementSystem.Implementation.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IBookingServices _bookingServices;
        private readonly ILogger<PaymentServices> _logger;

        public PaymentServices(ApplicationDbContext dbContext, IBookingServices bookingServices, ILogger<PaymentServices> logger)
        {
            _dbContext = dbContext;
            _bookingServices = bookingServices;
            _logger = logger;
        }

        public async Task<BaseResponse<Guid>> CreatePayment(CreatePayment request)
        {
            _logger.LogInformation("CreatePayment called with BookingId: {BookingId}", request.BookingId);

            try
            {
                var payment = new Payment
                {
                    BookingId = request.BookingId,
                    PaymentMethod = request.PaymentMethod,
                    PaymentDate = request.PaymentDate,
                    Amount = request.Amount,
                    Balance = request.Balance,
                    PaymentStatus = request.PaymentStatus
                };

                _dbContext.payments.Add(payment);
                await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Payment created successfully with Id: {PaymentId}", payment.Id);

                return new BaseResponse<Guid>
                {
                    Success = true,
                    Message = "Payment created successfully.",
                    Data = payment.Id
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Payment creation failed for BookingId: {BookingId}", request.BookingId);
                return new BaseResponse<Guid>
                {
                    Success = false,
                    Message = "Payment creation failed."
                };
            }
        }

        public async Task<PaymentDto> GetPaymentById(Guid paymentId)
        {
            _logger.LogInformation("GetPaymentById called with PaymentId: {PaymentId}", paymentId);

            var payment = await _dbContext.payments.FindAsync(paymentId);
            if (payment == null)
            {
                _logger.LogWarning("Payment not found with Id: {PaymentId}", paymentId);
                return null;
            }

            _logger.LogInformation("Payment retrieved successfully with Id: {PaymentId}", paymentId);

            return new PaymentDto
            {
                PaymentId = payment.Id,
                BookingId = payment.BookingId,
                PaymentMethod = payment.PaymentMethod,
                PaymentDate = payment.PaymentDate,
                Amount = payment.Amount,
                Balance = payment.Balance,
                PaymentStatus = payment.PaymentStatus
            };
        }

        public async Task<List<PaymentDto>> GetPayment()
        {
            _logger.LogInformation("GetPayment called.");

            var payments = await _dbContext.payments
                .Select(x => new PaymentDto
                {
                    Amount = x.Amount,
                    Balance = x.Balance,
                    BookingId = x.BookingId,
                    PaymentDate = x.PaymentDate,
                    PaymentId = x.Id,
                    PaymentMethod = x.PaymentMethod,
                    PaymentStatus = x.PaymentStatus
                }).ToListAsync();

            _logger.LogInformation("Payments retrieved successfully, count: {Count}", payments.Count);

            return payments;
        }

        public async Task<BaseResponse<IList<PaymentDto>>> GetAllPaymentAsync()
        {
            _logger.LogInformation("GetAllPaymentAsync called.");

            var payments = await _dbContext.payments
                .Select(x => new PaymentDto
                {
                    Amount = x.Amount,
                    Balance = x.Balance,
                    BookingId = x.BookingId,
                    PaymentDate = x.PaymentDate,
                    PaymentId = x.Id,
                    PaymentMethod = x.PaymentMethod,
                    PaymentStatus = x.PaymentStatus
                }).ToListAsync();

            _logger.LogInformation("All payments retrieved successfully, count: {Count}", payments.Count);

            return new BaseResponse<IList<PaymentDto>>
            {
                Success = true,
                Message = "Payments successfully retrieved.",
                Data = payments
            };
        }
    }
}
