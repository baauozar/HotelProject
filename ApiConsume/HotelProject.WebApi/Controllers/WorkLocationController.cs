using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService workLocation;

        public WorkLocationController(IWorkLocationService workLocation)
        {
            this.workLocation = workLocation;
        }

        [HttpGet]
        public IActionResult WorkLocationList()
        {
            var values = workLocation.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddWorkLocation(WorkLocation workLocations)
        {
            workLocation.TInsert(workLocations);

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletesWorkLocation(int id)
        {
            var value = workLocation.TGetByID(id);
            workLocation.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateWorkLocation(WorkLocation workLocations)
        {
            workLocation.TUpdate(workLocations);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetWorkLocation(int id)
        {
            var value = workLocation.TGetByID(id);
            return Ok(value);
        }
    }
}
