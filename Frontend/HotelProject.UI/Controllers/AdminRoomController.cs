using FluentValidation;
using HotelProject.UI.Dtos.RoomDto;
using HotelProject.UI.Model.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace HotelProject.UI.Controllers
{
    public class AdminRoomController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IValidator<UpdateRoomDto> _updateValidator;
        private readonly IValidator<CreateRoomDto> _createValidator;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;


        public AdminRoomController(IHttpClientFactory httpClientFactory, IValidator<UpdateRoomDto> updateValidator, IValidator<CreateRoomDto> createValidator, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Room");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
                // Deserialize jsonData to a model if needed
                var roomList = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                return View(roomList);
            }
            else
            {
                // Handle error response
                ModelState.AddModelError("", "Error retrieving staff data.");
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateRoom()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoom(CreateRoomDto model)
        {
            if (!await ValidateAsync(model, _createValidator, ModelState))
            {
                return View(model);
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_apiBaseUrl}/api/Room", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                // Optionally, you can redirect to the index or another action
                return RedirectToAction("Index");
            }
            else
            {
                // Handle error response
                ModelState.AddModelError("", "Error creating staff member.");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_apiBaseUrl}/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                // Optionally, you can redirect to the index or another action
                return RedirectToAction("Index");
            }
            else
            {
                // Handle error response
                ModelState.AddModelError("", "Error deleting staff member.");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var room = JsonConvert.DeserializeObject<UpdateRoomDto>(jsonData);
                return View(room);
            }
            else
            {
                ModelState.AddModelError("", "Error retrieving staff data for editing.");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditRoom(UpdateRoomDto model)
        {
            if (!await ValidateAsync(model, _updateValidator, ModelState))
            {
                return View(model);
            }
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_apiBaseUrl}/api/Room/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error retrieving staff data for editing.");
            }
            return View();
        }

    }
}
