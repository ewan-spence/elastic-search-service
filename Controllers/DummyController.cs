using ElasticSearchService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase {

        private readonly HttpClient _httpClient;

        public DummyController(IHttpClientFactory httpClientFactory) {
            _httpClient = httpClientFactory.CreateClient("ClientsEngine");
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddToIndex([FromBody] NationalPark[] docList) {
            string docListString = JsonConvert.SerializeObject(docList);

            var httpResponse = await _httpClient.PostAsync("", new StringContent(docListString, Encoding.UTF8, "application/json"));

            return httpResponse;
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteFromIndex([FromBody] string[] ids) {
            var idsString = JsonConvert.SerializeObject(ids);

            var request = new HttpRequestMessage {
                Method = HttpMethod.Delete,
                Content = new StringContent(idsString, Encoding.UTF8, "application/json")
            };

            var httpResponse = await _httpClient.SendAsync(request);

            return httpResponse;
        }
    }
}
