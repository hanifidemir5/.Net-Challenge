using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KargoApp.Dto
{
    public class CarrierCreateDTO
    {
        [HiddenInput]
        public int CarrierId { get; set; }
        [Required]
        public string CarrierName { get; set; }
        [Required]
        public Boolean CarrierIsActive { get; set; }
        [Required]
        public int CarrierPlusDesiCost { get; set; }
    }
}
