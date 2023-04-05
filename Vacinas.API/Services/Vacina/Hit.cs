using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Vacinas.API.Services.Vacina
{
    public class Hit
    {
        [JsonProperty("_index")]
        [JsonPropertyName("_index")]
        public string Index { get; set; }

        [JsonProperty("_type")]
        [JsonPropertyName("_type")]
        public string Type { get; set; }

        [JsonProperty("_id")]
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonProperty("_score")]
        [JsonPropertyName("_score")]
        public double Score { get; set; }

        [JsonProperty("_source")]
        [JsonPropertyName("_source")]
        public Source Source { get; set; }

        [JsonProperty("total")]
        [JsonPropertyName("total")]
        public Total Total { get; set; }

        [JsonProperty("max_score")]
        [JsonPropertyName("max_score")]
        public double MaxScore { get; set; }

        [JsonProperty("hits")]
        [JsonPropertyName("hits")]
        public List<Hit> HitList { get; set; }
    }
}
