using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.AppUserDto;
using HotelProject.DtoLayer.Dtos.WorkLocationDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsersWithWorkLocation()
        {
            var users = _appUserService.TUsersListWithWorkLocation();
            var resultDto = _mapper.Map<List<ResultAppUserDto>>(users);
            return Ok(resultDto);
        }
    }
}
