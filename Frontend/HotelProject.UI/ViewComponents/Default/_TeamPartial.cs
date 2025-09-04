using HotelProject.UI.Dtos.AboutDto;
using HotelProject.UI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.UI.ViewComponents.Default
{
    public class _TeamPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;
        public _TeamPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiBaseUrl}/api/Staff");
            if (response.IsSuccessStatusCode)
            {
                var Jsondata = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultStaffDto>>(Jsondata);
                return View(value);
            }
            return View();
        }
    }
  
}
