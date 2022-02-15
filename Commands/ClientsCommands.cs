using ElasticSearchService.Entities;
using ElasticSearchService.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchService.Commands {
    public class ClientsCommands : IClientsCommands {
        private readonly HttpClient _client;
        private readonly string _endpoint = "clients/documents";
        private readonly string _privateKey;

        public ClientsCommands(IHttpClientFactory httpClientFactory, IConfiguration config) {
            _client = httpClientFactory.CreateClient("DocsAPI");

            _privateKey = config.GetSection("Clients").GetValue<string>("PrivateKey");

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _privateKey);
        }

        public async Task AddDummyClients(int rotations) {

            var firstNames = DummyDataHelper.GetFirstNames();
            var lastNames = DummyDataHelper.GetLastNames();
            var serviceTypes = DummyDataHelper.GetServiceTypes();
            var random = new Random();

            for (int i = 0; i < rotations; i++) {
                var clients = new List<Client>();
                for (int j = 0; j < 100; j++) {

                    var first = firstNames.ElementAt(random.Next(0, firstNames.Count));
                    var last = lastNames.ElementAt(random.Next(0, lastNames.Count));
                    clients.Add(new Client {
                        Id = Guid.NewGuid(),
                        Name = $"{first} {last}",
                        FirstName = first,
                        LastName = last,
                        DateJoined = DateTime.Now.AddMinutes(-random.Next(0, 1000000)),
                        DateOfBirth = DateTime.Now.AddDays(-random.Next(0, 366)).AddYears(-random.Next(20, 90)),
                        ServiceType = serviceTypes.ElementAt(random.Next(0, serviceTypes.Count))
                    });
                }
                await IndexClients(clients.ToArray());
            }
        }

        public async Task DeleteClients(params string[] ids) {
            var content = new StringContent(JsonConvert.SerializeObject(ids), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage {
                Content = content,
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_client.BaseAddress, _endpoint)
            };

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task IndexClients(params Client[] clients) {

            var content = new StringContent(JsonConvert.SerializeObject(clients), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_endpoint, content);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateClients(params Client[] clients) {
            var content = new StringContent(JsonConvert.SerializeObject(clients), Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync(_endpoint, content);

            response.EnsureSuccessStatusCode();
        }



    }
}
