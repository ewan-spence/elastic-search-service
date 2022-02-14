using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchService.Requests {
    public class SearchRequest {

        [JsonProperty("query")]
        public string Query { get; set; }
        [JsonProperty("page")]
        public RequestPagination Page { get; set; }
    }
}
