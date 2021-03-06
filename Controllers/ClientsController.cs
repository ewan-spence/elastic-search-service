using ElasticSearchService.Commands;
using ElasticSearchService.Entities;
using ElasticSearchService.Queries;
using ElasticSearchService.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace ElasticSearchService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase {
        private readonly IClientsCommands _commands;
        private readonly IClientQueries _queries;
        private readonly string _searchKey;

        public ClientsController(IClientsCommands commands, IClientQueries queries, IConfiguration config) {
            _commands = commands;
            _queries = queries;
            _searchKey = config.GetSection("Clients").GetValue<string>("SearchKey");
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(ClientSearchRequest search) {
            try {
                return Ok(await _queries.Search(search));
            }
            catch(Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("dummy")]
        public async Task<IActionResult> AddDummyClients(int rotations) {
            try {
                await _commands.AddDummyClients(rotations);
                return Ok();
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetSearchAPIKey() {
            return Ok(_searchKey);
        }

        [HttpPost]
        public async Task<IActionResult> IndexClients([FromBody] params Client[] clients) {
            try {
                await _commands.IndexClients(clients);
                return Ok();
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClients([FromBody] params string[] ids) {
            try {
                await _commands.DeleteClients(ids);
                return Ok();
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateClients([FromBody] params Client[] clients) {
            try {
                await _commands.UpdateClients(clients);
                return Ok();
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
    }
}
