using AutoMapper;
using ElasticSearchService.Entities;
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
    public class ClientQueries : IClientQueries {
        private readonly HttpClient _client;
        private readonly string _searchKey;
        private readonly string _endpoint = "more-clients/search";
        private readonly IMapper _mapper;

        public async Task<ClientSearchResponse> Search(ClientSearchRequest search) {

            var content = new StringContent(JsonConvert.SerializeObject(search), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_endpoint, content);
            response.EnsureSuccessStatusCode();
            var results = await response.Content.ReadAsStringAsync();
            var searchResult = _mapper.Map<ClientSearchResponse>(JsonConvert.DeserializeObject<ClientAppSearchResult>(results));
            return searchResult;
        }

        public ClientQueries(IHttpClientFactory httpClientFactory, IConfiguration config, IMapper mapper) {

            _client = httpClientFactory.CreateClient("DocsAPI");
            _searchKey = config.GetSection("Clients").GetValue<string>("SearchKey");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _searchKey);
            _mapper = mapper;
        }
    }
}
