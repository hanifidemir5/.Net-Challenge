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
            var carriers = _carriersRepository.GetCarriers;
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(carriers);
        }
    }
}
