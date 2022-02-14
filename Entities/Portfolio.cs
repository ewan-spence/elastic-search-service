using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchService.Entities {
    public class Portfolio {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("client_name")]
        public string ClientName { get; set; }
        [JsonProperty("advisor_name")]
        public string AdvisorName { get; set; }
        [JsonProperty("holdings")]
        public List<string> Holdings { get; set; }
        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }
    }

    public class Holding {

        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("fund_name")]
        public string FundName { get; set; }
        [JsonProperty("purchased")]
        public int Purchased { get; set; }
        [JsonProperty("last_value")]
        public double LastValue { get; set; }
    }
}
