using KargoApp.Models;

namespace KargoApp.Dto
{
    public class CarriersDTO
    {
        public ICollection<Carriers> Carriers{ get; set; }

        public string Message { get; set; }

    }
}
