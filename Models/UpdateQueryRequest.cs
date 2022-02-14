using ElasticSearchService.Entities;

namespace ElasticSearchService.Models {
    public class UpdateQueryRequest {
        public Client Filter { get; set; }
        public Client Update { get; set; }
    }
}
