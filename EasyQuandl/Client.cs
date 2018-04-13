using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quandl;
using System.Threading.Tasks;

namespace EasyQuandl
{
    public static class Client
    {
        public static DataSet GetDataSet(TimeSeriesParameters parameters, string apiKey)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            string content = Request.Execute(parameters, apiKey);

            JObject jContent = JObject.Parse(content);

            string dataSetKey = jContent.ContainsKey("dataset_data") ? "dataset_data" : "dataset";

            return JsonConvert.DeserializeObject<DataSet>(jContent[dataSetKey].ToString());
        }

        public static async Task<DataSet> GetDataSetAsync(TimeSeriesParameters parameters, string apiKey)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            string content = await Request.ExecuteAsync(parameters, apiKey);

            JObject jContent = JObject.Parse(content);

            string dataSetKey = jContent.ContainsKey("dataset_data") ? "dataset_data" : "dataset";

            return JsonConvert.DeserializeObject<DataSet>(jContent[dataSetKey].ToString());
        }

        public static DatabaseMetaData GetDatabaseMetaData(TimeSeriesParameters parameters, string apiKey)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            string content = Request.Execute(parameters, apiKey);

            JObject jContent = JObject.Parse(content);

            return JsonConvert.DeserializeObject<DatabaseMetaData>(jContent["database"].ToString());
        }

        public static async Task<DatabaseMetaData> GetDatabaseMetaDataAsync(TimeSeriesParameters parameters, string apiKey)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            string content = await Request.ExecuteAsync(parameters, apiKey);

            JObject jContent = JObject.Parse(content);

            return JsonConvert.DeserializeObject<DatabaseMetaData>(jContent["database"].ToString());
        }

        public static DataTable GetDataTable(TablesParameters parameters, string apiKey)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            string content = Request.Execute(parameters, apiKey);

            JObject jContent = JObject.Parse(content);

            return JsonConvert.DeserializeObject<DataTable>(jContent["datatable"].ToString());
        }

        public static async Task<DataTable> GetDataTableAsync(TablesParameters parameters, string apiKey)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            string content = await Request.ExecuteAsync(parameters, apiKey);

            JObject jContent = JObject.Parse(content);

            return JsonConvert.DeserializeObject<DataTable>(jContent["datatable"].ToString());
        }

        public static DataTableMetaData GetDataTableMetaData(TablesParameters parameters, string apiKey)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            string content = Request.Execute(parameters, apiKey);

            JObject jContent = JObject.Parse(content);

            return JsonConvert.DeserializeObject<DataTableMetaData>(jContent["datatable"].ToString());
        }

        public static async Task<DataTableMetaData> GetDataTableMetaDataAsync(TablesParameters parameters, string apiKey)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            string content = await Request.ExecuteAsync(parameters, apiKey);

            JObject jContent = JObject.Parse(content);

            return JsonConvert.DeserializeObject<DataTableMetaData>(jContent["datatable"].ToString());
        }
    }
}