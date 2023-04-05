using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Vacinas.API.Services.Vacina
{
    public class ResponseVacina
    {
        [JsonProperty("_scroll_id")]
        [JsonPropertyName("_scroll_id")]
        public string ScrollId { get; set; }

        [JsonProperty("took")]
        [JsonPropertyName("took")]
        public int Took { get; set; }

        [JsonProperty("timed_out")]
        [JsonPropertyName("timed_out")]
        public bool TimedOut { get; set; }

        [JsonProperty("_shards")]
        [JsonPropertyName("_shards")]
        public Shards Shards { get; set; }

        [JsonProperty("hits")]
        [JsonPropertyName("hits")]
        public Hit Hits { get; set; }
    }
}
