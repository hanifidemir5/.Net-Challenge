namespace KargoApp.Dto
{
    public class SingleOrderDTO
    {
        public int OrderId { get; set; }
        public int CarrierId { get; set; }
        public int OrderDesi { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal OrderCarrierCost { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
    }
}
