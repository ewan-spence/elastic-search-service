using Newtonsoft.Json;

namespace ElasticSearchService.Requests {
    public class RequestPagination {

        [JsonProperty("current")]
        public int Current { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
    }
}
