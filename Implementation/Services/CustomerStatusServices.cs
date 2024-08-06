using HotelManagementSystem.Dto;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Dto.ResponseModel;
using HotelManagementSystem.Implementation.Interface;
using HotelManagementSystem.Model.Entity;
using HotelManagementSystem.Models.Entity;
using Microsoft.EntityFrameworkCore;
namespace HotelManagementSystem.Implementation.Services
{
    public class CustomerStatusServices : ICustomerStatusServices
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IBookingServices _bookingServices;
        private readonly IUserServices _userServices;
        private readonly ILogger<CustomerStatusServices> _logger;

        public CustomerStatusServices(ApplicationDbContext dbContext, IBookingServices bookingServices, IUserServices userServices, ILogger<CustomerStatusServices> logger)
        {
            _dbContext = dbContext;
            _bookingServices = bookingServices;
            _userServices = userServices;
            _logger = logger;
        }

        public async Task<BaseResponse<Guid>> CheckIn(string customerId, Guid bookingId)
        {
            _logger.LogInformation("CheckIn called with customerId: {customerId}, bookingId: {bookingId}", customerId, bookingId);
            try
            {
                var customer = await _dbContext.Users.FindAsync(customerId);
                if (customer == null)
                {
                    _logger.LogWarning("Customer not found with Id: {customerId}", customerId);
                    return new BaseResponse<Guid>
                    {
                        Success = false,
                        Message = "Customer not found."
                    };
                }

                var customerStatus = new CustomerStatus
                {
                    BookingId = bookingId,
                    CustomerId = customerId,
                    CustomerName = customer.Name,
                    CheckInDate = DateTime.Now,
                };

                _dbContext.CustomerStatuses.Add(customerStatus);
                await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Check-in successful for customerId: {customerId}", customerId);
                return new BaseResponse<Guid>
                {
                    Success = true,
                    Message = "Check-in successful.",
                    Data = customerStatus.BookingId
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred during check-in for customerId: {customerId}", customerId);
                return new BaseResponse<Guid>
                {
                    Success = false,
                    Message = "Check-in failed.",
                };
            }
        }

        public async Task<BaseResponse<Guid>> CheckOut(Guid customerId)
        {
            _logger.LogInformation("CheckOut called with customerId: {customerId}", customerId);
            try
            {
                var customerStatus = await _dbContext.CustomerStatuses.FirstOrDefaultAsync(x => x.Id == customerId);
                if (customerStatus == null)
                {
                    _logger.LogWarning("CustomerStatus not found with Id: {customerId}", customerId);
                    return new BaseResponse<Guid>
                    {
                        Success = false,
                        Message = "Customer not found."
                    };
                }
                customerStatus.CheckOutDate = DateTime.Now;

                _dbContext.CustomerStatuses.Update(customerStatus);
                await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Check-out successful for customerId: {customerId}", customerId);
                return new BaseResponse<Guid>
                {
                    Success = true,
                    Message = "Check-out successful.",
                    Data = customerStatus.Id
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred during check-out for customerId: {customerId}", customerId);
                return new BaseResponse<Guid>
                {
                    Success = false,
                    Message = "Check-out failed.",
                };
            }
        }

        public async Task<List<CustomerStatusDto>> GetCustomerStatus()
        {
            _logger.LogInformation("GetCustomerStatus called");
            return await _dbContext.CustomerStatuses
                .Select(x => new CustomerStatusDto()
                {
                    Id = x.Id,
                    CheckInDate = x.CheckInDate,
                    CheckOutDate = x.CheckOutDate,
                    CustomerName = x.CustomerName,
                    CustomerId = x.Id
                }).ToListAsync();
        }

        public List<SelectCustomerDto> GetCustomerSelect()
        {
            _logger.LogInformation("GetCustomerSelect called");
            var customers = _dbContext.Users.ToList();
            var result = new List<SelectCustomerDto>();

            if (customers.Count > 0)
            {
                result = customers.Select(x => new SelectCustomerDto()
                {
                    Id = Guid.Parse(x.Id),
                    Name = x.Name,
                }).ToList();
            }

            return result;
        }

        public List<SelectCustomerCheckedInDto> GetSelectCustomerCheckedIn()
        {
            _logger.LogInformation("GetSelectCustomerCheckedIn called");
            var customerStatus = _dbContext.CustomerStatuses.ToList();
            var result = new List<SelectCustomerCheckedInDto>();

            if (customerStatus.Count > 0)
            {
                result = customerStatus.Select(x => new SelectCustomerCheckedInDto()
                {
                    Id = x.Id,
                    Name = x.CustomerName,
                }).ToList();
            }

            return result;
        }
    }
}
