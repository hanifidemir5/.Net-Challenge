using System.ComponentModel.DataAnnotations;

namespace KargoApp.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int CarrierId { get; set; }
        [Required]
        public int OrderDesi { get; set;}
        [Required]
        public DateTime OrderTime { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal OrderCarrierCost { get; set; }
        public Carriers Carrier { get; set; }
    }
}
