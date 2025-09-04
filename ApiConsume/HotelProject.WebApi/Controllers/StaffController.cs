using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult StaffList()
        {
            var values= _staffService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Addstaff(Staff staff)
        {
            _staffService.TInsert(staff);

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletestaff(int id)
        {
            var value=_staffService.TGetByID(id);
            _staffService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult Updatestaff(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Getstaff(int id)
        {
            var value = _staffService.TGetByID(id);
            return Ok(value);
        }
        [HttpGet("LastForStaff")]
        public IActionResult LastForStaff()
        {
            var value = _staffService.TGetStaffList();
            return Ok(value);
        }
    }
}
