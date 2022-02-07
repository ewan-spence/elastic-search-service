using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ElasticSearchService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase {
        private readonly string _APIKey;

        public APIController(IConfiguration config) {
            _APIKey = config.GetValue<string>("SearchKey");
        }

        [HttpGet]
        public IActionResult GetAPIKey() {
            return Ok(_APIKey);
        }
    }
}
