using KargoApp.Models;
using KargoApp.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

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
            return Ok(carrierConfigurations);
        }
    }
}
