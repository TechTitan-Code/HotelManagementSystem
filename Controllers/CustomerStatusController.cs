using AspNetCoreHero.ToastNotification.Abstractions;
using HMS.Implementation.Services;
using HotelManagementSystem.Dto;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Implementation.Interface;
using HotelManagementSystem.Implementation.Services;
using HotelManagementSystem.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Controllers
{
    public class CustomerStatusController : Controller
    {
        private readonly ICustomerStatusServices _customerStatusServices;
        private readonly INotyfService _notyf;

        public CustomerStatusController(ICustomerStatusServices customerStatusServices , INotyfService notyf) 
        {
            _customerStatusServices = customerStatusServices;
            _notyf = notyf;
        }

        [HttpGet("get-customerStatus")]
        public async Task<IActionResult> CustomerStatus()
        {
            var status = await _customerStatusServices.GetCustomerStatus();
            return View(status);
        }


        [HttpGet("check-in")]
        public IActionResult CheckIn()
        {
            var customers = _customerStatusServices.GetCustomerSelect();
            ViewBag.Customers = new SelectList(customers, "Id", "Name");
            return View();
        }

        [HttpPost("check-in")]
        public async Task<IActionResult> CheckIn(Guid customerId, Guid bookingId)
        {
            var response = await _customerStatusServices.CheckIn(customerId, bookingId);
            if (response.Success)
            {
                _notyf.Success(response.Message, 3);
                return RedirectToAction("CustomerStatus");
            }

            ModelState.AddModelError(string.Empty, response.Message);
            _notyf.Error(response.Message);
            return View();
        }

        [HttpGet("check-out")]
        public IActionResult CheckOut()
        {
            var customers = _customerStatusServices.GetCustomerSelect();
            ViewBag.Customers = new SelectList(customers, "Id", "Name");
            return View();
        }

        [HttpPost("check-out")]
        public async Task<IActionResult> CheckOut(Guid customerId, Guid bookingId)
        {
            var response = await _customerStatusServices.CheckOut(customerId, bookingId);
            if (response.Success)
            {
                _notyf.Success(response.Message, 3);
                return RedirectToAction("CustomerStatus");
            }
            _notyf.Error(response.Message);
            return BadRequest();
        }
    }

}

