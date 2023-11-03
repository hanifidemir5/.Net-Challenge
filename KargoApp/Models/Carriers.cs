
using System.ComponentModel.DataAnnotations;

namespace KargoApp.Models
{
    public class Carriers
    {
        [Required]
        public int CarrierId { get; set; }
        [Required]
        public string CarrierName { get; set; }
        [Required]
        public Boolean CarrierIsActive { get; set;}
        [Required]
        public int CarrierPlusDesiCost { get; set; }
        [Required]
        public int CarrierConfigurationId { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<CarrierConfigurations> CarrierConfigurations { get; set; }
    }
}
