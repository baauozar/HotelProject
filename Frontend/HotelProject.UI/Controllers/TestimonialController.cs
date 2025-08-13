using HotelProject.UI.Model.Staff;
using HotelProject.UI.Model.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.UI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync("https://localhost:44369/api/Testimonial");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
                // Deserialize jsonData to a model if needed
                var staffList = JsonConvert.DeserializeObject<List<TestimonialViewModal>>(jsonData);
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
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(TestimonialViewModal model)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44369/api/Testimonial", content);
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

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44369/api/Testimonial/{id}");
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
        public async Task<IActionResult> EditTestimonial(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44369/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var staff = JsonConvert.DeserializeObject<TestimonialViewModal>(jsonData);
                return View(staff);
            }
            else
            {
                ModelState.AddModelError("", "Error retrieving staff data for editing.");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditTestimonial(UpdateStaffViewModal model)
        {
            var client = httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44369/api/Staff/", content);
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
