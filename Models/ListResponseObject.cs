using System.Collections.Generic;

namespace ElasticSearchService.Models {
    public class ListResponseObject<T> {
        public Meta Meta { get; set; }
        public List<T> Results { get; set; }   
    }

    public class Meta {
        public Page Page { get; set; }
    }
}
