using AutoMapper;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;
using HotelProject.UI.Dtos.AboutDto;
using HotelProject.UI.Dtos.AppUserDto;
using HotelProject.UI.Dtos.BookingDto;
using HotelProject.UI.Dtos.ContactDto;
using HotelProject.UI.Dtos.GuestDto;
using HotelProject.UI.Dtos.LoginDto;
using HotelProject.UI.Dtos.Register;
using HotelProject.UI.Dtos.SendMessageDto;
using HotelProject.UI.Dtos.Service;
using HotelProject.UI.Dtos.SubscribeDto;
using HotelProject.UI.Dtos.WorkLocationDto;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace HotelProject.UI.Mapping
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();

            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ApproveReservationDto, Booking>().ReverseMap();

            CreateMap<ResultGuestDto, Guest>().ReverseMap();
            CreateMap<CreateGuestDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();

            CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<CreateContactDto, Contact>().ReverseMap();

            CreateMap<GetMessageByIDDto, SendMessage>().ReverseMap();
            CreateMap<CreateSendMessageDto, SendMessage>().ReverseMap();

            CreateMap<ResultWorkLocationDto, WorkLocation>().ReverseMap();
            CreateMap<CreateWorkLocationDto, WorkLocation>().ReverseMap();
            CreateMap<UpdateWorkLocationDto, WorkLocation>().ReverseMap();

            CreateMap<ResultAppUserDto, AppUser>().ReverseMap();

         }
    }
}
