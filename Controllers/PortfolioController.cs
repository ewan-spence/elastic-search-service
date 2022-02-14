using ElasticSearchService.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchService.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : ControllerBase {
        private readonly IPortfolioCommands _commands;

        [HttpPost("dummy")]
        public async Task<IActionResult> AddDummyPortfolios(int rotations) {
            try {
                await _commands.AddDummyPortfolios(rotations);
                return Ok();
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }



        public PortfolioController(IPortfolioCommands portfolioCommands) {

            _commands = portfolioCommands;
        }
    }
}
