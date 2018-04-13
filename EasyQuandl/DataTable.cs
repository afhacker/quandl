using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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