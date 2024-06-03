using HotelManagementSystem.Dto;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Dto.ResponseModel;

namespace HotelManagementSystem.Implementation.Interface
{
    public interface ICustomerServices
    {
        Task<BaseResponse<Guid>> CreateCustomer(CreateCustomer request);
        Task<BaseResponse<Guid>> DeleteCustomerAsync(int Id);
        Task<BaseResponse<IList<CustomerDto>>> GetCustomerByIdAsync(int Id);
        Task<BaseResponse<CustomerDto>> GetCustomerAsync(int Id);
        Task<BaseResponse<IList<CustomerDto>>> GetAllCustomerCreatedAsync();
        Task<BaseResponse<CustomerDto>> UpdateCustomer(int Id, UpdateCustomer request);
        Task<List<CustomerDto>> GetCustomer();
    }
}
