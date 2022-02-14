using ElasticSearchService.Entities;
using ElasticSearchService.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchService.Commands {
    public class PortfolioCommands : IPortfolioCommands {
        private readonly HttpClient _client;
        private readonly string _privateKey;
        private readonly string _endpoint = "portfolios/documents";

        public async Task IndexPortfolios(params Portfolio[] portfolios) {

            var content = new StringContent(JsonConvert.SerializeObject(portfolios), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_endpoint, content);

            //response.EnsureSuccessStatusCode();

        }

        public async Task DeletePortfolios(params string[] ids) {

        }

        public async Task UpdatePortfolios(params Portfolio[] portfolios) {

        }

        public async Task AddDummyPortfolios(int rotations) {

            var funds = DummyDataHelper.GetDummyFunds();
            var firstNames = DummyDataHelper.GetFirstNames();
            var lastNames = DummyDataHelper.GetLastNames();
            var advisorNames = DummyDataHelper.GetAdviserNames();
            var random = new Random();


            for (int i = 0; i < rotations; i++) {
                var portfolios = new List<Portfolio>();
                for (int j = 0; j < 20; j++) {
                    var portfolio = new Portfolio
                    {
                        AdvisorName = advisorNames.ElementAt(random.Next(0, advisorNames.Count)),
                        ClientName = $"{firstNames.ElementAt(random.Next(0, firstNames.Count))} {lastNames.ElementAt(random.Next(0, lastNames.Count))}",
                        Id = Guid.NewGuid(),
                        DateCreated = DateTime.Now.AddDays(-random.Next(0, 10000)),
                        Holdings = new List<string>()
                    };
                    for (int k = 0; k < random.Next(3, funds.Count); k++) {
                        var fund = funds.ElementAt(random.Next(0, funds.Count));
                        while (DummyDataHelper.FundAlreadyIn(fund, portfolio.Holdings)) fund = funds.ElementAt(random.Next(0, funds.Count));
                        portfolio.Holdings.Add(fund);
                    }
                    portfolios.Add(portfolio);
                }
                await IndexPortfolios(portfolios.ToArray());
            }

        }



        public PortfolioCommands(IHttpClientFactory httpClientFactory, IConfiguration config) {
            _client = httpClientFactory.CreateClient("DocsAPI");

            _privateKey = config.GetSection("Clients").GetValue<string>("PrivateKey");

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _privateKey);
        }
    }
}
