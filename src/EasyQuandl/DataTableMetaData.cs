using Newtonsoft.Json;
using System.Collections.Generic;

namespace EasyQuandl
{
    public class DataTableMetaData
    {
        [JsonProperty("VendorCode")]
        public string VendorCode { get; set; }

        [JsonProperty("datatable_code")]
        public string DatatableCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("columns")]
        public List<DataTableColumn> Columns { get; set; }

        [JsonProperty("filters")]
        public List<string> Filters { get; set; }

        [JsonProperty("primary_key")]
        public List<string> PrimaryKey { get; set; }

        [JsonProperty("premium")]
        public bool Premium { get; set; }

        [JsonProperty("status")]
        public DataTableStatus Status { get; set; }
    }
}