using HotelProject.UI.Dtos.ContactDto;
using HotelProject.UI.Dtos.MessageCategoryDto;
using HotelProject.UI.Model.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.UI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;
        public ContactController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var categories = await GetCategoriesAsync();

            var model = new ContactFormViewModel
            {
                Contact = new CreateContactDto(),
                Categories = categories
            };

            return View(model);
        }

        [HttpGet]
        public async Task<PartialViewResult> SendMessage()
        {
            var categories = await GetCategoriesAsync();

            var model = new ContactFormViewModel
            {
                Contact = new CreateContactDto(),
                Categories = categories
            };

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(ContactFormViewModel model)
        {
            model.Categories = await GetCategoriesAsync();
            if (!ModelState.IsValid)
            {
                return View("Index",model);
            }

            model.Contact.Date = DateTime.Now;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model.Contact);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_apiBaseUrl}/api/Contact", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }

            ModelState.AddModelError("", "Error creating contact.");
            model.Categories = await GetCategoriesAsync();
            return View("Index",model);
        }

        private async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiBaseUrl}/api/MessageCategory");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);

                return categories.Select(x => new SelectListItem
                {
                    Text = x.MessageCategoryName,
                    Value = x.MessageCategoryID.ToString()
                }).ToList();
            }

            return new List<SelectListItem>();
        }
    }
}
