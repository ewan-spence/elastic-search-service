using Newtonsoft.Json;

namespace ElasticSearchService.Models {
    public class Page {
        public int Current { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
