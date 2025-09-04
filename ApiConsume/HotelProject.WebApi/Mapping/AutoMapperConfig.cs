using AutoMapper;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using HotelProject.DtoLayer.Dtos.WorkLocationDto;
using HotelProject.DtoLayer.Dtos.AppUserDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
            CreateMap<ResultAppUserDto, AppUser>().ReverseMap(); ;
            CreateMap<WorkLocation, ResultWorkLocation>().ReverseMap();

        }
    }
}
