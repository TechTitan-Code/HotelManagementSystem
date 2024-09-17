using HMS.Implementation.Services;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Implementation.Interface;
using HotelManagementSystem.Implementation.Services;
using HotelManagementSystem.Model.Entity;
using HotelManagementSystem.Model.Entity.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HotelManagementSystem.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaystackService _paystackService;
        private readonly ApplicationDbContext _dbContext;

        public PaymentController(IPaystackService paystackService, ApplicationDbContext dbContext)
        {
            _paystackService = paystackService;
            _dbContext = dbContext;
        }

        [HttpGet("initiate-payment-form")]
        public IActionResult InitiatePaymentForm(string userId, Guid bookingId)
        {
            // Prepare the model with userId and bookingId
            var model = new InitializePaymentRequestDto
            {
                UserId = userId,
                BookingId = bookingId
            };

            return View(model);
        }

        [HttpPost("payment/initiate/{userId}/{bookingId}/{orderId}")]
        public async Task<IActionResult> InitiatePayment(InitializePaymentRequestDto requestDto, [FromRoute] string userId, [FromRoute] Guid bookingId)
        {
            if (!ModelState.IsValid)
            {
                // Pass back the userId, bookingId, and orderId on failure
                requestDto.UserId = userId;
                requestDto.BookingId = bookingId;
                return View("InitiatePaymentForm", requestDto);
            }

            var result = await _paystackService.InitializePaymentAsync(requestDto, userId, bookingId);

            if (result.Success)
            {
                return Redirect(result.Data.AuthorizationUrl);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View("InitiatePaymentForm", requestDto);
        }


        [HttpGet("VerifyPayment")]
        public IActionResult VerifyPaymentForm()
        {
            // Render a view that contains a form for entering the payment reference
            return View();
        }

        [HttpGet("PaymentCallback")]
        public async Task<IActionResult> PaymentCallback(string reference)
        {
            if (string.IsNullOrEmpty(reference))
            {
                return RedirectToAction("InitiatePayment"); // Redirect to the payment initiation if no reference is provided
            }

            // Call the service to verify the payment using the reference
            var result = await _paystackService.VerifyPaymentAsync(reference);

            if (result.Success)
            {
                // Payment successful, display the success view
                ViewBag.Reference = reference;
                return View("PaymentSuccess");
            }
            else
            {
                // Payment failed, display an error or handle as needed
                ModelState.AddModelError(string.Empty, "Payment verification failed. Please try again.");
                return View("PaymentFailed");
            }
        }


        public IActionResult PaymentSuccess(string reference)
        {
            // You can show the payment success page
            ViewBag.Reference = reference;
            return View();
        }
    }
}
