using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public Room2Controller(IMapper mapper, IRoomService roomService)
        {
            _mapper = mapper;
            _roomService = roomService;
        }
        [HttpGet]
        public IActionResult GetRoomList()
        {
            var values =  _roomService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom(RoomAddDto roomAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var room = _mapper.Map<Room>(roomAddDto);
            _roomService.TInsert(room);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var room = _mapper.Map<Room>(updateRoomDto);
            _roomService.TUpdate(room);
            return Ok();
        }
    }
}
