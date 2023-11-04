using AutoMapper;
using KargoApp.Dto;
using KargoApp.Models;

namespace KargoApp.Helper
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
               CreateMap<Orders, UpdateOrderDTO>().ReverseMap();
               CreateMap<Carriers,CreateCarrierDTO>().ReverseMap();   
               CreateMap<Carriers,CarriersDTO>().ReverseMap();
               CreateMap<CarrierConfigurations,UpdateCarrierConfigurationDTO>().ReverseMap();
               CreateMap<OrdersDTO, Orders>().ReverseMap();
               CreateMap<CarrierConfigurationsDTO, CarrierConfigurations>().ReverseMap();

        }
    }
}
