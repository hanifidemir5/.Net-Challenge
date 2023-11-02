namespace KargoApp.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int CarrierId { get; set; }
        public int OrderDesi { get; set;}
        public DateTime OrderTime { get; set; }
        public decimal OrderCarrierCost { get; set; }
    }
}
