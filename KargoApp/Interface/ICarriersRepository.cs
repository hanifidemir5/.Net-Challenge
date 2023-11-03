using KargoApp.Models;

namespace KargoApp.Interface
{
    public interface ICarriersRepository
    {
        ICollection<Carriers> GetCarriers();
    }
}
