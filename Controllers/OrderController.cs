using HotelManagementSystem.Dto.RequestModel;
using HotelManagementSystem.Implementation.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelManagementSystem.Controllers
{

    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
           
        }


        [HttpGet("get-order")]
        public async Task<IActionResult> Orders()
        {
            var order = await _orderServices.GetOrder();
            return View(order);
           // return View(new List<OrderDto>());
        }



       


        [HttpGet("create-order")]
        public IActionResult CreateOrder()
        {
            var products = _orderServices.GetProductSelect();
            ViewBag.Products = new SelectList(products, "Id", "ProductName");

            return View();
        }


        

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder(CreateOrder request)
        {
            var order = await _orderServices.CreateOrder(request);
            if (order.Success)
            {
                return RedirectToAction("Orders");
            }
            return BadRequest();
        }


        [HttpGet("edit-order/{id}")]
        public async Task<IActionResult> EditOrder([FromRoute] Guid id)
        {
            var order = await _orderServices.GetOrderAsync(id);

            return View(order.Data);
        }


        [HttpPost("edit-order/{id}")]
        public async Task<IActionResult> EditOrder(UpdateOrder request)
        {

            var order = await _orderServices.UpdateOrder(request.Id, request);
            if (order.Success)
            {
                return RedirectToAction("Orders");
            }
            return View(request);
        }




        [HttpGet("delete-order/{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
        {
            var order = await _orderServices.DeleteOrderAsync(id);
            if (order.Success)
            {
                return RedirectToAction("Orders", "Order");
            }

            return BadRequest(order);

        }


        [HttpGet("get-all-order-created")]
        public async Task<IActionResult> GetAllOrderAsync()
        {
            var order = await _orderServices.GetAllOrderAsync();
            if (order.Success)
            {
                return View(order);
            }
            else
            {
                return BadRequest(order);
            }


        }

        [HttpGet("get-order/{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _orderServices.GetOrderByIdAsync(id);
            if (order != null)
            {
                return View(order.Data);
            }
            return RedirectToAction("Orders");
        }


       
    }
}



