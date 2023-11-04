using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KargoApp.Dto
{
    public class CreateCarrierDTO
    {
        [Required]
        public string CarrierName { get; set; }
        [Required]
        public Boolean CarrierIsActive { get; set; }
        [Required]
        public int CarrierPlusDesiCost { get; set; }
        [Required]
        public int CarrierConfigurationId { get; set; }
    }
}
