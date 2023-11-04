using System.ComponentModel.DataAnnotations;

namespace KargoApp.Dto
{
    public class UpdateOrderDTO
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int OrderDesi {get; set;}
        [Required]
        public DateTime OrderTime{ get; set;}
    }
}
