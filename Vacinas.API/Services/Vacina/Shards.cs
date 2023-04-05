using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vacinas.API.Services.Vacina
{
    public class Shards
    {
        [JsonProperty("total")]
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonProperty("successful")]
        [JsonPropertyName("successful")]
        public int Successful { get; set; }

        [JsonProperty("skipped")]
        [JsonPropertyName("skipped")]
        public int Skipped { get; set; }

        [JsonProperty("failed")]
        [JsonPropertyName("failed")]
        public int Failed { get; set; }
    }
}
