using ElasticSearchService.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchService.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase {
        private readonly IClientCommands _commands;

        [HttpPost("dummy")]
        public async Task<IActionResult> AddDummyClients(int rotations) {
            try {
                await _commands.AddDummyClients(rotations);
                return Ok();
            }
            catch(Exception e) {
                return StatusCode(500, e.Message);
            }
        }



        public ClientController(IClientCommands commands) {

            _commands = commands;

        }
    }
}
