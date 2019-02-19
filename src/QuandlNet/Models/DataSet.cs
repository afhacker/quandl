using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace QuandlNet.Models
{
    public class DataSet
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("dataset_code")]
        public string Code { get; set; }

        [JsonProperty("database_code")]
        public string DatabaseCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("refreshed_at")]
        public DateTimeOffset RefreshedAt { get; set; }

        [JsonProperty("newest_available_date")]
        public DateTime NewestAvailableDate { get; set; }

        [JsonProperty("oldest_available_date")]
        public DateTime OldestAvailableDate { get; set; }

        [JsonProperty("column_names")]
        public List<string> ColumnNames { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("premium")]
        public bool Premium { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("transform")]
        public string Transform { get; set; }

        [JsonProperty("column_index")]
        public int? ColumnIndex { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("data")]
        public List<IList> Data { get; set; }

        [JsonProperty("collapse")]
        public string Collapse { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }

        [JsonProperty("database_id")]
        public long DatabaseID { get; set; }
    }
}