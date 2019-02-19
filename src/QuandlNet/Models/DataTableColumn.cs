using Newtonsoft.Json;

namespace QuandlNet.Models
{
    public class DataTableColumn
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}