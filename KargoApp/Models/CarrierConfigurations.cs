using System.ComponentModel.DataAnnotations;

namespace KargoApp.Models
{
    public class CarrierConfigurations
    {
        [Required]
        public int CarrierConfigurationId { get; set; }
        [Required]
        public int CarrierId { get; set; }
        [Required]
        public int CarrierMaxDesi { get; set;}
        [Required]
        public int CarrierMinDesi { get;set;}
        [Required]
        public decimal CarrierCost { get; set;}

    }
}
