using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchService.Models {
    public class PortfolioResultModel {
        [JsonProperty("id")]
        public StringResponseField Id { get; set; }
        [JsonProperty("advisor_name")]
        public StringResponseField AdvisorName { get; set; }
        [JsonProperty("client_name")]
        public StringResponseField ClientName { get; set; }
        [JsonProperty("date_created")]
        public StringResponseField DateCreated { get; set; }
        [JsonProperty("holdings")]
        public ListResponseField Holdings { get; set; }
    }
}
