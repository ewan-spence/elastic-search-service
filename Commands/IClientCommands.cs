using ElasticSearchService.Entities;
using System.Threading.Tasks;

namespace ElasticSearchService.Commands {
    public interface IClientCommands {
        Task AddDummyClients(int rotations);
        Task IndexClients(params Client[] users);
    }
}