using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchService.Models {
    public class SearchResultMeta {
        [JsonProperty("engine")]
        public Engine Engine { get; set; }
        [JsonProperty("page")]
        public Page Page { get; set; }
        [JsonProperty("precision")]
        public int Precision { get; set; }
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }

    public class Page {
        public int Current { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
    }

    public class Engine {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
