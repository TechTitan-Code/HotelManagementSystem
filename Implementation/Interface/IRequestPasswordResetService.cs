using HotelManagementSystem.Dto;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Dto.ResponseModel;

namespace HotelManagementSystem.Implementation.Interface
{
    public interface IRequestPasswordResetService
    {
        Task<BaseResponse<bool>> CreateNewPassWord(CreateNewPassWord request);
        Task<BaseResponse<bool>> ValidateResetCodeAsync(ValidateResetCodeRequest request);
    }
}
