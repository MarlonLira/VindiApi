﻿using Newtonsoft.Json;

namespace VindiSdk.Models
{
    public class State
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
