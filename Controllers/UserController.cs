using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Implementation.Interface;
using HotelManagementSystem.Implementation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
       

        public UserController(IUserServices  userService)
        {
            _userServices = userService;
        }


        [HttpGet("get-user")]
        public async Task<IActionResult> Users()
        {
            var user = await _userServices.GetUser();
            return View(user);
        }

        [HttpGet("create-user")]
        public async Task<IActionResult> CreateUser()
        {
            var user = await _userServices.GetAllUserAsync();
            if (user.Success)
            {

                return View();
            }
            return BadRequest();
        }




        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUser request)
        {
            
         var user = await   _userServices.CreateUser(request);
            if (user.Success)
            {
                return RedirectToAction("Users");
            }
            return BadRequest();
        }


        [HttpGet("edit-user/{id}")]
        public async Task<IActionResult> EditUser([FromRoute] Guid id)
        {
            var user = await _userServices.GetUserAsync(id);

            return View(user.Data);
        }

         
        [HttpPost("edit-user/{id}")]
        public async Task<IActionResult> EditUser(UpdateUser request)
        {
           var user = await _userServices.UpdateUser(request.Id, request);
            if (user.Success)
            {
                return RedirectToAction("Users");
            }
            return View(user);
        }


        [HttpGet("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _userServices.DeleteUserAsync(id);
            if (user.Success)
            {
                return RedirectToAction("Users", "User");
            }
            return BadRequest(user);
        }



        [HttpGet("get-all-user-created")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userServices.GetAllUserAsync();
            if (users.Success)
            {
                return RedirectToAction("Users");
            }
            return View(users);

        }



        //[HttpGet("get-user-by-id/{id}")]
        //public async Task<IActionResult> GetUserById(Guid id)
        //{
        //    var user = await _userServices.GetUserByIdAsync(id);
        //    if (user.Success)
        //    {
        //        return RedirectToAction("Users");
        //    }
        //    return View(user);
        //}


        [HttpGet("get-user-by-id/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userServices.GetUserByIdAsync(id);
            if (user.Success && user.Data != null)
            {
                return View(user.Data); 
            }
            return RedirectToAction("Users"); 
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _userServices.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Admin" );
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordModel changePasswordModelDto, string username)
        {

            var result = await _userServices.ChangePasswordAsync(changePasswordModelDto, username);
            return RedirectToAction(nameof(Login));

        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _userServices.LogOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
