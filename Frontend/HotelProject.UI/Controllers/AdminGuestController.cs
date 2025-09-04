using FluentValidation;
using HotelProject.EntityLayer.Concrete;
using HotelProject.UI.Dtos.GuestDto;
using HotelProject.UI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.UI.Controllers
{
    public class AdminGuestController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IValidator<CreateGuestDto> _createValidator;
        private readonly IValidator<UpdateGuestDto> _updateValidator;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;



        public AdminGuestController(IHttpClientFactory httpClientFactory, IValidator<CreateGuestDto> createValidator, IValidator<UpdateGuestDto> updateValidator, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Guest");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
                // Deserialize jsonData to a model if needed
                var guestList = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
                return View(guestList);
            }
            else
            {
                // Handle error response
                ModelState.AddModelError("", "Error retrieving staff data.");
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateGuest()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGuest(CreateGuestDto model)
        {
            if (!await ValidateAsync(model,_createValidator,ModelState))
            {
             
                return View(model);
            }
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync($"{_apiBaseUrl}/api/Guest", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                  
                    return RedirectToAction("Index");
                }
                else
                {
                  
                    return View(model);
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_apiBaseUrl}/api/Guest/{id}");
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
        public async Task<IActionResult> EditGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Guest/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var guest = JsonConvert.DeserializeObject<UpdateGuestDto>(jsonData);
                return View(guest);
            }
            else
            {
                ModelState.AddModelError("", "Error retrieving staff data for editing.");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditGuest(UpdateGuestDto model)
        {
            if (!await ValidateAsync(model, _updateValidator, ModelState))
            {
                return View(model);
            }
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_apiBaseUrl}/api/Guest/", content);
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
