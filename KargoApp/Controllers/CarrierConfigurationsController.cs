using KargoApp.Models;
using KargoApp.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using KargoApp.Dto;
using KargoApp.Repository;
using AutoMapper;

namespace KargoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationsController : Controller
    {
        private readonly ICarrierConfigurationsRepository _configurationRepository;
        private readonly IMapper _mapper;
        public CarrierConfigurationsController(ICarrierConfigurationsRepository configurationRepository, ICarriersRepository carriersRepository, IMapper mapper)
        {
            _configurationRepository = configurationRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<CarrierConfigurations>))]
        
        public IActionResult GetCarrierConfigurations()
        {
            var carrierConfigurations = _configurationRepository.GetCarrierConfigurations();    
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = new CarrierConfigurationsDTO()
            {
                Message = "İstek başarılı",
                StatusCode = 200,
                Succeeded = true,
                CarrierConfigurations = carrierConfigurations,
            };
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateCarrierConfiguration([FromBody] CreateCarrierConfigurationDTO carrierConfigurationCreate)
        {
            if(carrierConfigurationCreate == null)
            {
                return BadRequest(ModelState);
            }

            if(carrierConfigurationCreate.CarrierMaxDesi <= carrierConfigurationCreate.CarrierMinDesi)
            {
                var response = new SingleOrderDTO()
                {
                    Message = "Maxdesi Mindesi'den büyük olamaz",
                    StatusCode = 400,
                    Succeeded = false,
                };
                return BadRequest(response);
            }

            var carrierConfigurationInstance = new CarrierConfigurations
            {
                CarrierId = carrierConfigurationCreate.CarrierId,
                CarrierCost = carrierConfigurationCreate.CarrierCost,
                CarrierMaxDesi = carrierConfigurationCreate.CarrierMaxDesi,
                CarrierMinDesi = carrierConfigurationCreate.CarrierMinDesi
            };
            _configurationRepository.CreateCarrierConfiguration(carrierConfigurationInstance);  

            var confId = carrierConfigurationInstance.CarrierConfigurationId;

            return Ok( confId + " numaralı configuration başarı ile oluşturuldu!!");
        }
        [HttpPut("{carrierConfigurationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateCarrierConfiguration(int carrierConfigurationId,UpdateCarrierConfigurationDTO updatedCarrierConfiguration)
        {
            if (updatedCarrierConfiguration.CarrierMaxDesi <= updatedCarrierConfiguration.CarrierMinDesi)
            {
                var response = new SingleOrderDTO()
                {
                    Message = "Maxdesi Mindesi'den büyük olamaz",
                    StatusCode = 400,
                    Succeeded = false,
                };
                return BadRequest(response);
            }

            if (updatedCarrierConfiguration == null)
                return BadRequest(ModelState);

            var order = _configurationRepository.GetCarrierConfigurations().FirstOrDefault(p => p.CarrierConfigurationId == carrierConfigurationId);


            if (order == null)
                return NotFound("Kargo Konfigürasyonu bulunamadı!!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carrierConfigurationMap = _mapper.Map<CarrierConfigurations>(updatedCarrierConfiguration);
            carrierConfigurationMap.CarrierConfigurationId = carrierConfigurationId;    
          
            if (!_configurationRepository.UpdateCarrierConfiguration(carrierConfigurationMap))
            {
                ModelState.AddModelError("", "Bir şeyler ters gitti!!");
                return StatusCode(500, ModelState);
            }
            return Ok("{carrierConfigurationId} cumaralı konfigürasyon başarı ile güncellendi!!");
        }
        [HttpDelete("{carrierConfigurationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCarrier(int carrierConfigurationId)
        {
            if (!_configurationRepository.CarrierConfigurationExist(carrierConfigurationId))
                return NotFound(ModelState);
            var carrierConfigurationToDelete = _configurationRepository.GetCarrierConfigurations().FirstOrDefault(p => p.CarrierConfigurationId == carrierConfigurationId);

            if (carrierConfigurationToDelete == null)
                return BadRequest("Sipariş bulunamadı!!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            if (!_configurationRepository.DeleteCarrierConfiguration(carrierConfigurationToDelete))
            {
                ModelState.AddModelError("", "Silme sırasında birşeyler ters gitti.");
            }
            return Ok("Konfigürasyon silme başarılı.");
        }

    }
}
