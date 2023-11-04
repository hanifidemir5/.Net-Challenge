using KargoApp.Models;

namespace KargoApp.Dto
{
    public class CarriersDTO
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public ICollection<Carriers> Carriers{ get; set; }
    }
}
