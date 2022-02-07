using System.Collections.Generic;

namespace ElasticSearchService.Models {
    public class NationalPark {
        public string Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string Nps_link { get; set; }
        public List<string> States { get; set; }
        public int Visitors { get; set; }
        public bool World_heritage_site { get; set; }
        public string Location { get; set; }
        public float Acres { get; set; }
        public float Square_km { get; set; }
        public string Date_established { get; set; }
    }
}
