using HMS.Implementation.Services;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Implementation.Interface;
using HotelManagementSystem.Implementation.Services;
using HotelManagementSystem.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentServices _paymentServices;

        public PaymentController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
        }

        [HttpGet("get-payment")]
        public async Task<IActionResult> Payments()
        {
            var payment = await _paymentServices.GetPayment();
            return View(payment);
        }



        [HttpGet("create-payment")]
        public async Task<IActionResult> CreatePayment()
        {
            var response = await _paymentServices.GetAllPaymentAsync();
            if (response.Success)
            {
                return View();
            }
            return BadRequest();
        }


        [HttpPost("create-payment")]
        public async Task<IActionResult> CreatePayment(CreatePayment request)
        {

            var payment = await _paymentServices.CreatePayment(request);
            if (payment.Success)
            {
                return RedirectToAction("Payments");
            }

            return BadRequest();


        }
    }
}
