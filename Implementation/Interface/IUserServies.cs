using HotelManagementSystem.Dto;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Dto.ResponseModel;

namespace HotelManagementSystem.Implementation.Interface
{
    public interface IUserServices
    {
        Task<BaseResponse<Guid>> CreateUser(CreateUser request);
        Task<BaseResponse<Guid>> DeleteUserAsync(int id);
        Task<BaseResponse<IList<UserDto>>> GetUserByIdAsync(int Id);
        Task<BaseResponse<UserDto>> GetUserAsync(int Id);
        Task<BaseResponse<IList<UserDto>>> GetAllUserAsync();
        Task<BaseResponse<IList<UserDto>>> UpdateUser(int Id, UpdateUser request);
        Task<List<UserDto>> GetUser();

    }
}
