using Newtonsoft.Json;
using System;

namespace ElasticSearchService.Entities {
    public class Client {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("first_name")]
        public string? FirstName { get; set; }
        [JsonProperty("last_name")]
        public string? LastName { get; set; }
        [JsonProperty("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }
        [JsonProperty("date_joined")]
        public DateTime? DateJoined { get; set; }
        [JsonProperty("service_type")]
        public string? ServiceType { get; set; }
    }
}
