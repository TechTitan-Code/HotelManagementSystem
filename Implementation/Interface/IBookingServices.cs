using HotelManagementSystem.Dto;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Dto.ResponseModel;

namespace HotelManagementSystem.Implementation.Interface
{
    public interface IBookingServices
    {
        Task<BaseResponse<Guid>> CreateBooking(CreateBooking request, int Id);
        Task<BaseResponse<Guid>> DeleteBookingAsync(int Id);
        Task<BaseResponse<IList<BookingDto>>> GetBookingByIdAsync(int Id);
        Task<BaseResponse<IList<BookingDto>>> GetAllBookingsAsync();
        Task<BaseResponse<BookingDto>> UpdateBooking(int Id, UpdateBooking request);
        Task<BaseResponse<BookingDto>> GetBookingAsync(int Id);
        Task<List<BookingDto>> GetBooking();




    }
}
