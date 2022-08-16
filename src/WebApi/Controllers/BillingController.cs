using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Business;
using Models.Filters;
using Models.Mapper.Request;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {

        private readonly IBillingService _billingService;

        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet()]
        public IActionResult Get([FromQuery] BillingFilter billingFilter)
        {
            return Ok( _billingService.Get(billingFilter));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BillingPost billing)
        {
            var result = await _billingService.Create((Billing)billing);
            return Created(result.Id, result);
        }
    }
}
