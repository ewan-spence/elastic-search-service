using ElasticSearchService.Commands;
using ElasticSearchService.Queries;
using ElasticSearchService.Requests;
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
        private readonly IPortfolioQueries _queries;

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

        [HttpPost("search")]
        public async Task<IActionResult> Search(SearchRequest search) {
            try {
                return Ok(await _queries.Search(search));
            }
            catch(Exception e) {
                return StatusCode(500, e.Message);
            }
        }



        public PortfolioController(IPortfolioCommands portfolioCommands, IPortfolioQueries queries) {

            _commands = portfolioCommands;
            _queries = queries;
        }
    }
}
