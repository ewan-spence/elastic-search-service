using ElasticSearchService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticSearchService.Services {
    public interface IClientsService {
        public Task<List<Client>> UpdateByQuery(Client filter, Client update);
    }
}
