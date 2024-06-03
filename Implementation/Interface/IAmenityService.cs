using HotelManagementSystem.Dto;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Dto.ResponseModel;

namespace HMS.Implementation.Interface
{
    public interface IAmenityService
    {
        Task<BaseResponse<IList<AmenityDto>>> CreateAmenity(CreateAmenityRequestModel request);
        Task<BaseResponse<Guid>> DeleteAmenity(int Id);
        Task<BaseResponse<IList<AmenityDto>>> GetAmenityBYId(int Id);
        Task<BaseResponse<IList<AmenityDto>>> GetAllAmenity();
        Task<BaseResponse<AmenityDto>> UpdateAmenity(int Id, UpdateAmenity request);
        Task<BaseResponse<AmenityDto>> GetAmenityAsync(int Id);
        Task<List<AmenityDto>> GetAmenity();
    }
}
