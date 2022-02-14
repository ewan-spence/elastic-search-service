using ElasticSearchService.Commands;
using ElasticSearchService.Entities;
using ElasticSearchService.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ElasticSearchService.Services {
    public class ClientsService : IClientsService {
        private readonly IClientsCommands _commands;

        public ClientsService(IClientsCommands commands) {
            _commands = commands;
        }

        public async Task UpdateByQuery(Client filter, Client update) {
            // Temporary loop limit before first request
            var totalPages = int.MaxValue;
            for (int pageNumber = 1; pageNumber < totalPages; pageNumber++) {

                // Retreive relevant clients 
                List<Client> filteredClients;
                (filteredClients, totalPages) = await _commands.GetClients(pageNumber, filter);

                // If this page has no relevant clients, continue to the next page
                if (filteredClients.Count == 0) continue;

                var patchList = new Client[filteredClients.Count];

                for (int index = 0; index < filteredClients.Count; index++)  {
                    var client = filteredClients[index];

                    // Iterate through `update` properties and set non-null fields to `client`
                    foreach (var prop in typeof(Client).GetProperties()) {
                        if (prop.Name == "Id") continue;

                        if (prop.GetValue(update) != null) {
                            prop.SetValue(client, prop.GetValue(update));
                        }
                    }

                    // Append modified `client` object to the request body
                    patchList.SetValue(client, index);
                }

                await _commands.UpdateClients(patchList);
            }
        }
    }
}
