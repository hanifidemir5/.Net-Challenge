using KargoApp.Models;

namespace KargoApp.Dto
{
    public class OrdersDTO
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public ICollection<Orders> Orders { get; set;}
    }
}
