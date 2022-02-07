using ElasticSearchService.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchService.Commands {
    public class ClientsCommands : IClientsCommands {
        private readonly HttpClient _client;
        private readonly string _endpoint = "clients/documents";

        public ClientsCommands(IHttpClientFactory httpClientFactory) {
            _client = httpClientFactory.CreateClient("DocsAPI");
        }

        public async Task AddDummyClients(int rotations) {

            var firstNames = GetFirstNames();
            var lastNames = GetLastNames();
            var random = new Random();

            for (int i = 0; i < rotations; i++) {
                var clients = new List<Client>();
                for (int j = 0; j < 50; j++) {

                    var first = firstNames.ElementAt(random.Next(0, firstNames.Count));
                    var last = lastNames.ElementAt(random.Next(0, lastNames.Count));
                    clients.Add(new Client {
                        Id = Guid.NewGuid(),
                        Name = $"{first} {last}",
                        FirstName = first,
                        LastName = last,
                        DateJoined = DateTime.Now.AddMinutes(-random.Next(0, 1000000)),
                        DateOfBirth = DateTime.Now.AddDays(-random.Next(0, 366)).AddYears(-random.Next(20, 90))
                    });
                }
                await IndexClients(clients.ToArray());
            }
        }

        public async Task DeleteClients(params string[] ids) {
            var content = new StringContent(JsonConvert.SerializeObject(ids), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage {
                Content = content,
                Method = HttpMethod.Delete
            };

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task IndexClients(params Client[] clients) {

            var content = new StringContent(JsonConvert.SerializeObject(clients), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_endpoint, content);

            response.EnsureSuccessStatusCode();
        }

        public Task UpdateClients(params Client[] clients) {
            throw new NotImplementedException();
        }

        private List<string> GetFirstNames() {
            return new List<string>
            {
                "Ross",
                "Ewan",
                "Lewis",
                "David",
                "John",
                "James",
                "Michael",
                "Paul",
                "Mary",
                "Emma",
                "Lisa",
                "Hollie",
                "Frank",
                "Louise",
                "Gemma",
                "Pauline",
                "Claire",
                "Chloe",
                "Christopher",
                "Luke",
                "Jordan",
                "Jamie",
                "Nicole",
                "Greg"
            };
        }

        private List<string> GetLastNames() {

            return new List<string>
            {
                "Lyons",
                "Spence",
                "McCarthy",
                "Bain",
                "Jack",
                "Smith",
                "Gordon",
                "Halkett",
                "Souttar",
                "Boyle",
                "McGregor",
                "Davis",
                "Kent",
                "Johnston",
                "Considine",
                "Ferguson",
                "Taylor",
                "Forster",
                "Hart",
                "Armstrong"
            };
        }
    }
}
