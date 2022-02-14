using AutoMapper;
using ElasticSearchService.Models;
using ElasticSearchService.Requests;
using ElasticSearchService.Responses;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchService.Queries {
    public class PortfolioQueries : IPortfolioQueries {
        private readonly HttpClient _client;
        private readonly string _searchKey;
        private readonly IMapper _mapper;
        private readonly string _endpoint = "portfolios/search";

        public async Task<PortfolioSearchResponse> Search(SearchRequest search) {

            var content = new StringContent(JsonConvert.SerializeObject(search), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_endpoint, content);
            response.EnsureSuccessStatusCode();
            var results = await response.Content.ReadAsStringAsync();
            var searchResult = _mapper.Map<PortfolioSearchResponse>(JsonConvert.DeserializeObject<PortfolioAppSearchResult>(results));
            return searchResult;
        }

        public PortfolioQueries(IHttpClientFactory httpClientFactory, IConfiguration config, IMapper mapper) {

            _client = httpClientFactory.CreateClient("DocsAPI");
            _searchKey = config.GetSection("Clients").GetValue<string>("SearchKey");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _searchKey);
            _mapper = mapper;
        }
    }
}
