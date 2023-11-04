using System.ComponentModel.DataAnnotations;

namespace KargoApp.Dto
{
    public class UpdateCarrierConfigurationDTO
    {
        [Required]
        public int CarrierId { get; set; }
        [Required]
        public int CarrierMaxDesi { get; set; }
        [Required]
        public int CarrierMinDesi { get; set; }
        [Required]
        public decimal CarrierCost { get; set; }
    }
}
