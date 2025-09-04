using HotelProject.UI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Configuration;

namespace HotelProject.UI.ViewComponents.Dashboard
{
    public class _DashboardStuffPartial: ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;



        public _DashboardStuffPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
         
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Staff/LastForStaff");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
                // Deserialize jsonData to a model if needed
                var StaffList = JsonConvert.DeserializeObject<List<ResultLastStaff>>(jsonData);

                return View(StaffList);

            }
            
         
            return View();
        }
    }
}
