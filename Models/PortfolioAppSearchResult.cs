using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchService.Models {
    public class PortfolioAppSearchResult {
        [JsonProperty("meta")]
        public SearchResultMeta Meta { get; set; }
        [JsonProperty("results")]
        public List<PortfolioResultModel> Results { get; set; }
    }
}
