using ElasticSearchService.Entities;
using System.Threading.Tasks;

namespace ElasticSearchService.Commands {
    public interface IClientsCommands {
        Task AddDummyClients(int rotations);
        Task IndexClients(params Client[] clients);
        Task DeleteClients(params string[] ids);
        Task UpdateClients(params Client[] clients);
    }
}