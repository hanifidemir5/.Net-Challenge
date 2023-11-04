using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KargoApp.Dto
{
    public class CreateCarrierConfigurationDTO
    {
        [HiddenInput]
        public int CarrierConfigurationId { get; set; }
        [Required]
        public int CarrierMaxDesi { get; set; }
        [Required]
        public int CarrierMinDesi { get; set; }
        [Required]
        public decimal CarrierCost { get; set; }

    }
}
