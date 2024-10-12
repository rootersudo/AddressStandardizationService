using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AddressStandardizationService.Services;
using AddressStandardizationService.models;

namespace AddressStandardizationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IDadataService _dadataService;

        public AddressController(IDadataService dadataService)
        {
            _dadataService = dadataService;
        }

        [HttpGet]
        public async Task<IActionResult> StandardizeAddress([FromQuery] string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return BadRequest("Address is required");
            }

            var request = new AddressRequest { Address = address };
            var response = await _dadataService.StandardizeAddressAsync(request);
            return Ok(response);
        }
    }
}