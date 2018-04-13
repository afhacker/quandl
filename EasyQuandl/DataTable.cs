using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace EasyQuandl
{
    public class DataTable
    {
        [JsonProperty("data")]
        public IList Data { get; set; }

        [JsonProperty("columns")]
        public List<DataTableColumn> Columns { get; set; }
    }
}