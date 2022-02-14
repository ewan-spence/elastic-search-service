using ElasticSearchService.Requests;
using ElasticSearchService.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticSearchService.Queries {
    public interface IClientQueries {
        Task<ClientSearchResponse> Search(ClientSearchRequest query);
    }
}