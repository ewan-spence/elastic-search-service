using ElasticSearchService.Entities;
using System.Threading.Tasks;

namespace ElasticSearchService.Services {
    public interface IClientsService {
        public Task UpdateByQuery(Client filter, Client update);
    }
}
