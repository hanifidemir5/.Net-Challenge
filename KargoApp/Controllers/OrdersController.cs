using KargoApp.Dto;
using KargoApp.Interface;
using KargoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Net;

namespace KargoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Orders>))]
        public IActionResult GetOrders()
        {
            var orders = _orderRepository.GetOrders();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = new OrdersDTO()
            {
                Message = "İstek başarılı",
                StatusCode = 200,
                Succeeded = true,
                Orders = orders,
            };
            return Ok(response);
        }

        [HttpGet("[action]/{orderId}")]
        [ProducesResponseType(200, Type = typeof(Orders))]
        [ProducesResponseType(400)]
        public IActionResult GetOrders(int orderId)
        {
            var order = _orderRepository.GetOrdersById(orderId);

            if (order == null)
            {
                var errorResponse = new SingleOrderErrorDTO()
                {
                    Message = "Sipariş Bulunamadı",
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                };
                return NotFound(errorResponse);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = new SingleOrderDTO()
            {
                CarrierId = order.CarrierId,
                Message = "Başarılı",
                OrderId = order.OrderId,
                OrderCarrierCost = order.OrderCarrierCost,
                OrderDesi = order.OrderDesi,
                OrderTime = order.OrderTime,
                Succeeded = true,
                StatusCode = (int)HttpStatusCode.OK,
            };
            return Ok(response);
        }
        [HttpGet("[action]/{orderDesi}")]
        [ProducesResponseType(200, Type = typeof(Orders))]
        [ProducesResponseType(400)]
        public IActionResult GetOrdersByDesi(int orderDesi)
        {
            var order = _orderRepository.GetOrdersByDesi(orderDesi);

            if (order == null)
            {
                var errorResponse = new SingleOrderErrorDTO()
                {
                    Message = "Sipariş Bulunamadı",
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                };
                return NotFound(errorResponse);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var response = new SingleOrderDTO()
            {
                CarrierId = order.CarrierId,
                Message = "Başarılı",
                OrderId = order.OrderId,
                OrderCarrierCost = order.OrderCarrierCost,
                OrderDesi = order.OrderDesi,
                OrderTime = order.OrderTime,
                Succeeded = true,
                StatusCode = (int)HttpStatusCode.OK,
            };
            return Ok(response);
        }
        [HttpGet("[action]/{orderTime}")]
        [ProducesResponseType(200, Type = typeof(Orders))]
        [ProducesResponseType(400)]
        public IActionResult GetOrdersByOrderTime(DateTime orderTime)
        {
            var order = _orderRepository.GetOrdersByOrderTime(orderTime);

            if (order == null)
            {
                var errorResponse = new SingleOrderErrorDTO()
                {
                    Message = "Sipariş Bulunamadı",
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                };
                return NotFound(errorResponse);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var response = new SingleOrderDTO()
            {
                CarrierId = order.CarrierId,
                Message = "Başarılı",
                OrderId = order.OrderId,
                OrderCarrierCost = order.OrderCarrierCost,
                OrderDesi = order.OrderDesi,
                OrderTime = order.OrderTime,
                Succeeded = true,
                StatusCode = (int)HttpStatusCode.OK,
            };
            return Ok(response);
        }
        [HttpGet("[action]/{orderCarrierCost}")]
        [ProducesResponseType(200, Type = typeof(Orders))]
        [ProducesResponseType(400)]
        public IActionResult GetOrdersByCarrierCost(decimal orderCarrierCost)
        {
            var order = _orderRepository.GetOrdersByCarrierCost(orderCarrierCost);

            if (order == null)
            {
                var errorResponse = new SingleOrderErrorDTO()
                {
                    Message = "Sipariş Bulunamadı",
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Succeeded = false,
                };
                return NotFound(errorResponse);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var response = new SingleOrderDTO()
            {
                CarrierId = order.CarrierId,
                Message = "Başarılı",
                OrderId = order.OrderId,
                OrderCarrierCost = order.OrderCarrierCost,
                OrderDesi = order.OrderDesi,
                OrderTime = order.OrderTime,
                Succeeded = true,
                StatusCode = (int)HttpStatusCode.OK,
            };
            return Ok(response);
        }



    }

}
