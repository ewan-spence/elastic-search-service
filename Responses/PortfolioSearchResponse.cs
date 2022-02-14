using ElasticSearchService.Entities;
using ElasticSearchService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchService.Responses {
    public class PortfolioSearchResponse {

        public SearchResultMeta Meta { get; set; }
        public List<Portfolio> Results { get; set; }
    }
}
