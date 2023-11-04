using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly ICarriersRepository _carriersRepository;
        private readonly ICarrierConfigurationsRepository _carrierConfigurationsRepository;
        public OrdersController(IOrderRepository orderRepository, IMapper mapper,ICarriersRepository carriersRepository,ICarrierConfigurationsRepository carrierConfigurationsRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _carriersRepository = carriersRepository;
            _carrierConfigurationsRepository = carrierConfigurationsRepository;
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOrder([FromBody] CreateOrderDTO orderCreate)
        {
            if (orderCreate == null)
                return BadRequest(ModelState);

            /*
             
            var order = _orderRepository.GetOrders()
                .Where(c => c.OrderTime == orderCreate.OrderTime).FirstOrDefault();
            
            if(order != null)
            {
                ModelState.AddModelError("", "Sipariş hali hazırda var!!");
                return StatusCode(422, ModelState);
            }
             */

            /*

            if (!_orderRepository.CreateOrder(orderMap))
            {
                ModelState.AddModelError("", "Kayıt oluştururken birşeyler ters gitti.");
                return StatusCode(500, ModelState);
            }
            */
            var orderInstance = new Orders
            {
                OrderDesi = orderCreate.OrderDesi,
                OrderTime = orderCreate.OrderTime
            };

            var carrierConfiguratins = _carrierConfigurationsRepository.GetCarrierConfigurationsWithCarrier();

            var properCarrierConfigurationList = carrierConfiguratins.Where(p => p.CarrierMinDesi <= orderInstance.OrderDesi && p.CarrierMaxDesi >= orderInstance.OrderDesi).MinBy(x => x.CarrierCost);
            
            if(properCarrierConfigurationList == null)
            {
                var closestDesiValue = carrierConfiguratins.Where(p => p.CarrierMaxDesi <= orderInstance.OrderDesi).OrderBy(x => x.CarrierMaxDesi).LastOrDefault();
                var difference = Math.Abs(orderInstance.OrderDesi - closestDesiValue.CarrierMaxDesi);
                var finalCost = (closestDesiValue.Carrier.CarrierPlusDesiCost * difference) + closestDesiValue.CarrierCost;
                orderInstance.OrderCarrierCost = finalCost;
                orderInstance.CarrierId = closestDesiValue.CarrierId;
            }
            else
            {
                orderInstance.CarrierId = properCarrierConfigurationList.CarrierId;
                orderInstance.OrderCarrierCost = properCarrierConfigurationList.CarrierCost;
            }

            _orderRepository.CreateOrder(orderInstance);

            var orderId = orderInstance.OrderId;


            return Ok( orderId + " numaralı sipariş başarı ile oluşturuldu.");
        }
        [HttpPut("{orderId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOrder(int orderId, [FromBody]UpdateOrderDTO updatedOrder) 
        {
            if (updatedOrder == null)
                return BadRequest(ModelState);

            if(orderId != updatedOrder.OrderId)
                return BadRequest(ModelState);

            var order = _orderRepository.GetOrdersById(orderId);

            if(order == null)
                return NotFound("Sipariş bulunamadı!!");

            if (!ModelState.IsValid)
                return BadRequest();

            var orderMap = _mapper.Map<Orders>(updatedOrder);

            orderMap.OrderDesi = updatedOrder.OrderDesi;
            if (!_orderRepository.UpdateOrder(orderMap))
            {
                ModelState.AddModelError("", "Bir şeyler ters gitti!!");
                return StatusCode(500, ModelState);
            }
            return Ok("{orderId} numaralı sipariş başarı ile güncellendi!!");
        }

        [HttpDelete("{orderId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOrders(int orderId)
        {
            if (!_orderRepository.OrderExist(orderId)) 
                return NotFound(ModelState);
            var orderToDelete = _orderRepository.GetOrders().FirstOrDefault(p => p.OrderId == orderId);
            
            if(orderToDelete == null)
                return BadRequest("Sipariş bulunamadı!!");
           
            if(!ModelState.IsValid)
                return BadRequest();

            if (!_orderRepository.DeleteOrder(orderToDelete))
            {
                ModelState.AddModelError("", "Silme sırasında birşeyler ters gitti.");
            }
            return Ok("Sipariş silme başarılı!!");
        }

    }
}
