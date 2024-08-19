using AspNetCoreHero.ToastNotification.Abstractions;
using HotelManagementSystem.Dto;
using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Implementation.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    public class PasswordResetController : Controller
    {
        private readonly IRequestPasswordResetService _passwordResetService;
        private readonly INotyfService _notyf;

        public PasswordResetController(IRequestPasswordResetService passwordResetService, INotyfService notyf)
        {
            _passwordResetService = passwordResetService;
            _notyf = notyf;
        }

        [HttpGet("enter-reset-code")]
        public IActionResult EnterResetCode()
        {
            return View();
        }

        [HttpPost("enter-reset-code")]
        public async Task<IActionResult> EnterResetCode(ValidateResetCodeRequest request)
        {
            var response = await _passwordResetService.ValidateResetCodeAsync(request);

            if (response.Success)
            {
                _notyf.Success(response.Message, 3);
                return RedirectToAction("Login", "User");
            }

            _notyf.Error(response.Message);
            return View();
        }

        [HttpGet("request-password-reset")]
        public IActionResult RequestPasswordReset()
        {
            return View();
        }

        [HttpPost("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset(CreateNewPassWord request)
        {
            var response = await _passwordResetService.CreateNewPassWord(request);

            if (response.Success)
            {
                _notyf.Success(response.Message, 3);
                return RedirectToAction("EnterResetCode");
            }

            _notyf.Error(response.Message);
            return View();
        }
    }
}
