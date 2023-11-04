using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KargoApp.Dto
{
    public class CreateOrderDTO
    {
        [Required]
        public int OrderDesi { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }
    }
}
