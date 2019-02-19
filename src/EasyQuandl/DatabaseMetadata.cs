using Newtonsoft.Json;

namespace EasyQuandl
{
    public class DatabaseMetaData
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("database_code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("datasets_count")]
        public long DatasetsCount { get; set; }

        [JsonProperty("downloads")]
        public long Downloads { get; set; }

        [JsonProperty("premium")]
        public bool Premium { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}