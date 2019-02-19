using Newtonsoft.Json;

namespace EasyQuandl
{
    public class DataTableColumn
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}