using ElasticSearchService.Requests;
using ElasticSearchService.Responses;
using System.Threading.Tasks;

namespace ElasticSearchService.Queries {
    public interface IPortfolioQueries {
        Task<PortfolioSearchResponse> Search(SearchRequest search);
    }
}