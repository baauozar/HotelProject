using AutoMapper;
using HotelProject.UI.Dtos.RoomDto;
using HotelProject.UI.Dtos.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.UI.ViewComponents.Default
{
    public class _RoomPartial: ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;


        public _RoomPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync($"{_apiBaseUrl}/api/Room");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
                // Deserialize jsonData to a model if needed
                var RoomList = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
               var firstThreeRooms = RoomList?.Take(3).ToList();
                return View(firstThreeRooms);
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
