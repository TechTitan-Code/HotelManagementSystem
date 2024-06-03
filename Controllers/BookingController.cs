using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Implementation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingServices _bookService;

        public BookingController(IBookingServices bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-booking")]
        public async Task<IActionResult> Index()
        {
            var response = await _bookService.GetBooking();
            return View(response);
        }


        public async Task<IActionResult> Create()
        {
            var roomsResponse = await _bookService.GetAllBookingsAsync();
            if (roomsResponse.Success)
            {
                ViewBag.Rooms = roomsResponse.Data;
                return View();
            }
            return BadRequest(roomsResponse.Message);
        }



        [HttpPost("create-booking")]
        public async Task<IActionResult> CreateBooking(CreateBooking request, int Id)
        {
            var booking = await _bookService.CreateBooking(request, Id);
            if (booking.Success)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }


        [HttpGet("edit-booking/{id}")]
        public async Task<IActionResult> EditBooking([FromRoute] int id)
        {
            var booking = await _bookService.GetBookingAsync(id);

            return View(booking.Data);
        }


        [HttpPost("Update-Booking")]
        public async Task<IActionResult> UpdateBooking(UpdateBooking request)
        {

            var booking = await _bookService.UpdateBooking(request.Id, request);
            if (booking.Success)
            {
                return RedirectToAction("Index");
            }
            return View("Booking");
        }




        [HttpGet("delete-booking/{id}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int id)
        {
            var booking = await _bookService.DeleteBookingAsync(id);
            if (booking.Success)
            {
                return RedirectToAction("Index", "Booking");
            }

            return BadRequest(booking);

        }


        [HttpGet("get-all-booking-created")]
        public async Task<IActionResult> GetAllBookingsAsync()
        {
            var bookings = await _bookService.GetAllBookingsAsync();
            if (bookings.Success == false)
            {
                return Ok(bookings);
            }
            else
            {
                return BadRequest(bookings);
            }


        }

        [HttpGet("get-booking-by-id/{id}")]
        public async Task<IActionResult> GetBookingByIdAsync(int id)
        {
            var bookings = await _bookService.GetBookingByIdAsync(id);
            if (bookings.Success == false)
            {
                return Ok(bookings);
            }
            else
            {
                return BadRequest(bookings);
            }
        }


    }
}
