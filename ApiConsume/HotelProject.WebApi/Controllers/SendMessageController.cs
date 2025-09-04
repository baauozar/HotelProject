using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService sendMessageService;

        public SendMessageController(ISendMessageService staffService)
        {
            this.sendMessageService = staffService;
        }

        [HttpGet]
        public IActionResult SenderMessageList()
        {
            var values = sendMessageService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSenderMessage(SendMessage sendMessage)
        {
            sendMessage.Date = Convert.ToDateTime(DateTime.Now.ToString());
            sendMessageService.TInsert(sendMessage);

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSenderMessage(int id)
        {
            var value = sendMessageService.TGetByID(id);
            sendMessageService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSenderMessage(SendMessage sendMessage)
        {
            sendMessageService.TUpdate(sendMessage);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSenderMessage(int id)
        {
            var value = sendMessageService.TGetByID(id);
            return Ok(value);
        }
        [HttpGet("GetSenderMessageCount")]
        public IActionResult GetSenderMessageCount()
        {
            var value = sendMessageService.TGetSendMessageCount();
            return Ok(value);
        }
    }
}
