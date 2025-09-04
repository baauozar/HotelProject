using HotelProject.UI.Dtos.RoomDto;
using HotelProject.UI.Dtos.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HotelProject.UI.ViewComponents.Default
{
    public class _ServicePartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;
        public _ServicePartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Service");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
                // Deserialize jsonData to a model if needed
                var ServiceList = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(ServiceList);
            }
            else
            {
                // Handle error response
                ModelState.AddModelError("", "Error retrieving staff data.");
            }
            return View();
        }
    }
}