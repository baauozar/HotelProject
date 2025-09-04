using FluentValidation;
using HotelProject.UI.Dtos.GuestDto;
using HotelProject.UI.Model.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.UI.Controllers
{
    public class StaffController : BaseController
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IValidator<AddStaffViewModel> _createValidator;
        private readonly IValidator<UpdateStaffViewModal> _updateValidator;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;

        public StaffController(IHttpClientFactory httpClientFactory, IValidator<AddStaffViewModel> createValidator, IValidator<UpdateStaffViewModal> updateValidator, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var client= httpClientFactory.CreateClient();
            var ResponseMessage= await client.GetAsync($"{_apiBaseUrl}/api/Staff");
            if(ResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
                // Deserialize jsonData to a model if needed
                 var staffList = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                return View(staffList);
            }
            else
            {
                // Handle error response
                ModelState.AddModelError("", "Error retrieving staff data.");
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStaff(AddStaffViewModel model)
        {
            if (!await ValidateAsync(model, _createValidator, ModelState))
            {

                return View(model);
            }
            var client= httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_apiBaseUrl}/api/Staff", content);
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
      
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_apiBaseUrl}/api/Staff/{id}");
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
        public async Task<IActionResult> EditStaff(int id) {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var staff = JsonConvert.DeserializeObject<UpdateStaffViewModal>(jsonData);
                return View(staff);
            }
            else
            {
                ModelState.AddModelError("", "Error retrieving staff data for editing.");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditStaff(UpdateStaffViewModal model) {
            if (!await ValidateAsync(model, _updateValidator, ModelState))
            {
                return View(model);
            }

            var client = httpClientFactory.CreateClient();
            var jsondata= JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_apiBaseUrl}/api/Staff/",content);
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
