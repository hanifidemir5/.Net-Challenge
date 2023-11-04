using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KargoApp.Dto
{
    public class OrderCreateDto
    {
        [HiddenInput]
        public int OrderId { get; set; }
        [Required]
        public int OrderDesi { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }
        [Required]
        public decimal OrderCarrierCost { get; set; }
    }
}
