using ElasticSearchService.Entities;
using System.Threading.Tasks;

namespace ElasticSearchService.Commands {
    public interface IPortfolioCommands {
        Task AddDummyPortfolios(int rotations);
        Task DeletePortfolios(params string[] ids);
        Task IndexPortfolios(params Portfolio[] portfolios);
        Task UpdatePortfolios(params Portfolio[] portfolios);
    }
}