
namespace KargoApp.Models
{
    public class Carriers
    {
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }
        public Boolean CarrierIsActive { get; set;}
        public int CarrierPlusDesiCost { get; set; }
        public int CarrierConfigurationId { get; set; }
        public ICollection<Orders> Orders { get; set; }

        public ICollection<CarrierConfigurations> CarrierConfigurations { get; set; }
    }
}
