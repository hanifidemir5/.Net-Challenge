using System.ComponentModel.DataAnnotations;

namespace KargoApp.Models
{
    public class Orders
    {
        [Required]
        public int OrderId { get; set; }
        public int CarrierId { get; set; }
        [Required]
        public int OrderDesi { get; set;}
        [Required]
        public DateTime OrderTime { get; set; }
        [Required]
        public decimal OrderCarrierCost { get; set; }
    }
}
