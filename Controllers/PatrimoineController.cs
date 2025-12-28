using Microsoft.AspNetCore.Mvc;
using PatrimoineAPI.Services;

namespace PatrimoineAPI.Controllers
{
    [ApiController]
    [Route("api/patrimoine")]
    public class PatrimoineController : ControllerBase
    {
        private readonly PatrimoineService _patrimoineService;

        public PatrimoineController(PatrimoineService patrimoineService)
        {
            _patrimoineService = patrimoineService;
        }

        // GET api/patrimoine/{userId}
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPatrimoine(int userId)
        {
            var response = await _patrimoineService.GetPatrimoineAsync(userId);
            return Ok(response);
        }
    }
}
