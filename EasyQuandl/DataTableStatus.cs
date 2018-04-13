using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EasyQuandl
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