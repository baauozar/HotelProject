using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok();
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut("BookingStatusChangeApproved/{id}")]
        public IActionResult BookingStatusChangeApproved(int id)
        {
            _bookingService.TBookingStatusChangeApproved(id);
            return Ok();
        }
        [HttpPut("BookingStatusChangeDecline/{id}")]
        public IActionResult BookingStatusChangeDecline(int id)
        {
            _bookingService.TBookingStatusChangeDecline(id);
            return Ok();
        }
        [HttpPut("BookingStatusChangeWaiting/{id}")]
        public IActionResult BookingStatusChangeWaiting(int id)
        {
            _bookingService.TBookingStatusChangeWaiting(id);
            return Ok();
        }
        [HttpGet("GetBookingCount")]
        public IActionResult GetBookingCount()
        {
            var value = _bookingService.TGetBookingCount();
            return Ok(value);
        }
        [HttpGet("GetLast6BookingCount")]
        public IActionResult GetLast6BookingCount()
        {
            var value = _bookingService.TGetLast6Bookings();
            return Ok(value);
        }

    }
}
