using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.EntityFramework;

namespace HotelProject.WebApi.Extension
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            // DAL registrations
            services.AddScoped<IStaffDal, EfStaffDal>();
            services.AddScoped<IServicesDal, EfServiceDal>();
            services.AddScoped<IRoomDal, EfRoomDal>();
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ISubscribeDal, EfSubscribeDal>();
            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IGuestDal, EfGuestDal>();
            services.AddScoped<ISendMessageDal, EfSendMessageDal>();
            services.AddScoped<IMessageCategoryDal, EfMessageCategoryDal>();
            services.AddScoped<IWorkLocationDal, EfWorkLocationDal>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();



            // Service registrations
            services.AddScoped<IStaffService, StaffManager>();
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IRoomService, RoomManager>();
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ISubscribeService, SubscribeManager>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IGuestService, GuestManager>();
            services.AddScoped<ISendMessageService, SendMessageManager>();
            services.AddScoped<IMessageCategoryService, MessageCategoryManager>();
            services.AddScoped<IWorkLocationService, WorkLocationManager>();
            services.AddScoped<IAppUserService, AppUserManager>();

            return services;
        }
    }
}

