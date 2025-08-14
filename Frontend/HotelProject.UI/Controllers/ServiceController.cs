using AutoMapper;
using HotelProject.UI.Dtos.Service;
using HotelProject.UI.Model.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.UI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMapper mapper;

       
        public ServiceController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            this.httpClientFactory = httpClientFactory;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync("https://localhost:44369/api/Service");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
                // Deserialize jsonData to a model if needed
                var staffList = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
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
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto model)
        {
            if(!ModelState.IsValid)
            {
                return View(); // Return the view with validation errors
            }
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44369/api/Service", content);
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
        public async Task<IActionResult> DeleteService(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44369/api/Service/{id}");
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
        public async Task<IActionResult> EditService(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44369/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                /*
                   Deserialize to the actual type returned by API (Service)
                var service = JsonConvert.DeserializeObject<Service>(jsonData);

                 Use AutoMapper to convert to UpdateServiceDto
                var updateServiceDto = mapper.Map<UpdateServiceDto>(service);

               
                 */
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var service = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(service);
            }
            else
            {
                ModelState.AddModelError("", "Error retrieving staff data for editing.");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditService(UpdateServiceDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(); // Return the view with validation errors
            }
            var client = httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44369/api/Service/", content);
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
