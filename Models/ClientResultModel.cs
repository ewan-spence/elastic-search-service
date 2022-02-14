using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchService.Models {
    public class ClientResultModel {

        [JsonProperty("id")]
        public StringResponseField Id { get; set; }
        [JsonProperty("first_name")]
        public StringResponseField FirstName { get; set; }
        [JsonProperty("last_name")]
        public StringResponseField LastName { get; set; }
        [JsonProperty("name")]
        public StringResponseField Name { get; set; }
        [JsonProperty("service_type")]
        public StringResponseField ServiceType { get; set; }
        [JsonProperty("date_of_birth")]
        public StringResponseField DateOfBirth { get; set; }
        [JsonProperty("date_joined")]
        public StringResponseField DateJoined { get; set; }

    }
}
