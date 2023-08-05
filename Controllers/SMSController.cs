using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSMS.DTOS;
using TestSMS.Sevices;

namespace TestSMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService smsService;

        public SMSController(ISMSService smsService)
        {
            this.smsService = smsService;
        }

        [HttpPost]
        public IActionResult Send(SMSDto dto)
        {
            var result = smsService.Send(dto.PhoneNumber, dto.MessageBody);
            if(!string.IsNullOrEmpty(result.ErrorMessage))
                return BadRequest(result.ErrorMessage);
            return Ok(result);
        }
    }
}
