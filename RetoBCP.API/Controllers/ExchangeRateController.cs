using Microsoft.AspNetCore.Mvc;
using RetoBCP.Application.Command;
using RetoBCP.Application.DTO;
using RetoBCP.Application.Query;

namespace RetoBCP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRateController : BaseApiController
    {
        public ExchangeRateController(IConfiguration Config) : base(Config)
        {
        }
        [HttpPost("/calculateAmountWithER")]
        public async Task<IActionResult> CalculateExchangeRate(CalculateExchangeRateRequest req)
        {
            return HandleResult(await Mediator!.Send(new GetCalculateExchangeRate.Query { Dto = req }));
        }

        [HttpPost("/updateExchangeRate")]
        public async Task<IActionResult> UpdateExchangeRate(UpdateExchangeRateRequest req)
        {
            return HandleResult(await Mediator!.Send(new UpdateExchangeRate.Command { Dto = req }));
        }
        [HttpGet("/getAllOrByIdExchangeRate")]
        public async Task<IActionResult> GetAllExchangeRate(int? Id)
        {
            return HandleResult(await Mediator!.Send(new GetAllExchangeRate.Query { Id = Id }));
        }
    }
}
