using HotelManagementSystem.Dto;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Dto.ResponseModel;

namespace HotelManagementSystem.Implementation.Interface
{
    public interface IProductServices
    {
        Task<BaseResponse<Guid>> CreateProduct(CreateProduct request);
        Task<BaseResponse<Guid>> DeleteProductAsync(int Id);
        
        Task<BaseResponse<IList<ProductDto>>> GetAllProductsByIdAsync(int Id);
        Task<BaseResponse<ProductDto>> GetProductAsync(int Id);
        Task<BaseResponse<IList<ProductDto>>> GetAllProductAsync();
        Task<BaseResponse<ProductDto>> UpdateProduct(int Id, UpdateProduct request);
    }
}
