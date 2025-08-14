using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.UI.Dtos.Service;

namespace HotelProject.UI.Mapping
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
         }
    }
}
