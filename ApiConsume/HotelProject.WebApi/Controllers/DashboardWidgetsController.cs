using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookservice;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;

   

        public DashboardWidgetsController(IStaffService staffService, IBookingService bookservice, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookservice = bookservice;
            _appUserService = appUserService;
            _roomService = roomService;
        }
        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        {
            var values = _staffService.TGetStaffCount();
            return Ok(values);
        }
        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var values = _bookservice.TGetBookingCount();
            return Ok(values);
        }
        [HttpGet("AppUserCount")]
        public IActionResult AppUserCount()
        {
            var values = _appUserService.TAppuserCount();
            return Ok(values);
        }
        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {
            var values = _roomService.TRoomCount();
            return Ok(values);
        }
    }
}
