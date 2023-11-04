using KargoApp.Dto;
using KargoApp.Interface;
using KargoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace KargoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : Controller
    {
        private readonly ICarriersRepository _carriersRepository;

        public CarriersController(ICarriersRepository carriersRepository)
        {
            _carriersRepository = carriersRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Carriers>))]

        public IActionResult GetCarriers()
        {
            var carriers = _carriersRepository.GetCarriers();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = new CarriersDTO(){ 
                Message = "İstek başarılı",
                StatusCode = 200,
                Succeeded = true,
                Carriers = carriers,
            };

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateCarrier([FromBody] CarrierCreateDTO carrierCreate)
        {
            if(carrierCreate == null)
                return BadRequest();

            var carrier = _carriersRepository.GetCarriers()
                .Where(carrier => carrier.CarrierId == carrierCreate.CarrierId).FirstOrDefault();

            if(carrier != null)
            {
                ModelState.AddModelError("", "Carrier hali hazırda var!!");
                return StatusCode(422,ModelState);
            }

            var carrierInstance = new Carriers
            {
                CarrierIsActive = carrierCreate.CarrierIsActive,
                CarrierName = carrierCreate.CarrierName,
                CarrierPlusDesiCost = carrierCreate.CarrierPlusDesiCost,
            };

            _carriersRepository.CreateCarrier(carrierInstance);

            var carrierId = carrierInstance.CarrierId;

            return Ok(carrierId + " numaralı carrier başarı ile oluşturuldu!!");
        }
    }
}
