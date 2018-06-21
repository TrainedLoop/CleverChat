using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleverChat.CleverBot
{
    public class CleverResponse
    {
        [JsonProperty("cs", NullValueHandling = NullValueHandling.Ignore)]
        public string Cs { get; set; }

        [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)]
        public string Input { get; set; }

        [JsonProperty("output", NullValueHandling = NullValueHandling.Ignore)]
        public string Output { get; set; }
    }
}
