using KargoApp.Models;
using KargoApp.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using KargoApp.Dto;

namespace KargoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationsController : Controller
    {
        private readonly ICarrierConfigurationsRepository _configurationRepository;

        public CarrierConfigurationsController(ICarrierConfigurationsRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
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
            return Ok(carrierConfigurations);
        }

        [HttpPost]

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateCarrierConfiguration([FromBody] CreateCarrierConfigurationDTO carrierConfigurationCreate)
        {
            if(carrierConfigurationCreate == null)
            {
                return BadRequest(ModelState);
            }

            var carrierConfiguration = _configurationRepository.GetCarrierConfigurations()
                .Where(conf => conf.CarrierConfigurationId == carrierConfigurationCreate.CarrierConfigurationId).FirstOrDefault();

            if (carrierConfiguration != null)
            {
                ModelState.AddModelError("", "Configuration hali hazırda var!!");
                return StatusCode(422, ModelState);
            }

            var carrierConfigurationInstance = new CarrierConfigurations
            {
                CarrierCost = carrierConfigurationCreate.CarrierCost,
                CarrierMaxDesi = carrierConfigurationCreate.CarrierMaxDesi,
                CarrierMinDesi = carrierConfigurationCreate.CarrierMinDesi
            };
            
            _configurationRepository.CreateCarrierConfiguration(carrierConfigurationInstance);  

            var confId = carrierConfigurationInstance.CarrierConfigurationId;

            return Ok( confId + " numaralı configuration başarı ile oluşturuldu!!");
        }
    }
}
