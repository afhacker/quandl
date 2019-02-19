using Newtonsoft.Json;
using System;

namespace QuandlNet.Models
{
    public class DataTableStatus
    {
        [JsonProperty("refreshed_at")]
        public DateTimeOffset RefreshedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("expected_at")]
        public DateTime? ExpectedAt { get; set; }

        [JsonProperty("update_frequency")]
        public string UpdateFrequency { get; set; }
    }
}