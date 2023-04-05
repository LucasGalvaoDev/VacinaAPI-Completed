using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vacinas.API.Services.Vacina
{
    public class Total
    {
        [JsonProperty("value")]
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonProperty("relation")]
        [JsonPropertyName("relation")]
        public string Relation { get; set; }
    }
}
