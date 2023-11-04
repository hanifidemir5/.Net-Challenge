using KargoApp.Models;

namespace KargoApp.Dto
{
    public class CarrierConfigurationsDTO
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public ICollection<CarrierConfigurations> CarrierConfigurations{ get; set; }
    }
}
