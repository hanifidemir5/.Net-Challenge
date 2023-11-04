using AutoMapper;
using KargoApp.Dto;
using KargoApp.Models;

namespace KargoApp.Helper
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
               CreateMap<Orders, SingleOrderDTO>();
        }
    }
}
