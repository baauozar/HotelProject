using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.UI.Dtos.AppUserDto;
using HotelProject.UI.Dtos.RoomDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.UI.Controllers
{
    public class AdminUsersController : Controller
    {
        
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;
        public AdminUsersController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/AppUser");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var userList = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsonData);
                return View(userList);
            }
            else
            {
                // Handle error response
                ModelState.AddModelError("", $"Error retrieving users: {responseMessage.StatusCode}");
                return View(new List<ResultAppUserDto>()); // Return empty list to avoid null reference
            }
        }
    }
}