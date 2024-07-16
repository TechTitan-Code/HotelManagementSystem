using HotelManagementSystem.Dto;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Dto.ResponseModel;

namespace HotelManagementSystem.Implementation.Interface
{
    public interface ICustomerStatusServices
    {
        Task<BaseResponse<Guid>> CheckIn(string customerId ,Guid bookingId);
        Task<List<CustomerStatusDto>> GetCustomerStatus();
        List<SelectCustomerDto> GetCustomerSelect();
        List<SelectBookingDto> GetBookingSelect();
        Task<BaseResponse<Guid>> CheckOut(string customerId, Guid bookingId);
    }
}
