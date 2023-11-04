using AutoMapper;
using KargoApp.Dto;
using KargoApp.Interface;
using KargoApp.Models;
using KargoApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace KargoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : Controller
    {
        private readonly ICarriersRepository _carriersRepository;
        private readonly IMapper _mapper;
        public CarriersController(ICarriersRepository carriersRepository, IMapper mapper)
        {
            _carriersRepository = carriersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Carriers>))]

        public IActionResult GetCarriers()
        {
            var carriers = _carriersRepository.GetCarriers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = new CarriersDTO()
            {
                Message = "İstek başarılı!!",
                Carriers = carriers
            };

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateCarrier([FromBody] CreateCarrierDTO carrierCreate)
        {
            if(carrierCreate == null)
                return BadRequest();

            var carrier = _carriersRepository.GetCarriers()
                .Where(carrier => carrier.CarrierName == carrierCreate.CarrierName).FirstOrDefault();
            
            if(carrier != null)
            {
                ModelState.AddModelError("", "Kargo firması hali hazırda var!!");
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

        [HttpPut("{carrierId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCarrier(int carrierId, [FromForm] CreateCarrierDTO updateCarrier)
        {
            var carrier = _carriersRepository.GetCarriers().FirstOrDefault(p => p.CarrierId == carrierId);
            if(UpdateCarrier == null)
                return BadRequest();

            if(carrier.CarrierName != updateCarrier.CarrierName)
                return BadRequest();

            if(carrier == null)
            {
                return NotFound("Kargo firması bulunamadı!!");
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var carrierMap = _mapper.Map<Carriers>(updateCarrier);

            if (!_carriersRepository.UpdateCarrier(carrierMap))
            {
                ModelState.AddModelError("", "Bir şeyler ters gitti!!");
                return StatusCode(500, ModelState);
            }
            return Ok("{carrierId} numaralı kargo şirketi başarı ile güncellendi!!");
        }
        [HttpDelete("{carrierId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCarrier(int carrierId)
        {
            if (!_carriersRepository.CarrierExist(carrierId))
                return NotFound(ModelState);
            var carrierToDelete = _carriersRepository.GetCarriers().FirstOrDefault(p => p.CarrierId== carrierId);

            if (carrierToDelete == null)
                return BadRequest("Sipariş bulunamadı!!");

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_carriersRepository.DeleteCarrier(carrierToDelete))
            {
                ModelState.AddModelError("", "Silme sırasında birşeyler ters gitti.");
            }
            return Ok("Kargo şirketi silme başarılı!!");
        }
    }
}
