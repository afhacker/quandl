using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuandlNet.Enums;
using QuandlNet.Models;
using System.Net;
using System.Threading.Tasks;

namespace QuandlNet
{
    public class Client
    {
        #region Fields

        private readonly BaseUrls _baseUrls;

        private readonly string _apiKey;

        #endregion Fields

        public Client(BaseUrls baseUrls, string apiKey)
        {
            _baseUrls = baseUrls;

            _apiKey = apiKey;
        }

        #region Methods

        public Task<string> RequestAsync(TimeSeriesParameters parameters)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadStringTaskAsync(Utility.GetURI(parameters, _baseUrls, _apiKey));
            }
        }

        public Task<string> RequestAsync(TablesParameters parameters)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadStringTaskAsync(Utility.GetURI(parameters, _baseUrls, _apiKey));
            }
        }

        public string Request(TimeSeriesParameters parameters)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(Utility.GetURI(parameters, _baseUrls, _apiKey));
            }
        }

        public string Request(TablesParameters parameters)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(Utility.GetURI(parameters, _baseUrls, _apiKey));
            }
        }

        public Task<byte[]> DownloadSeriesAsync(TimeSeriesParameters parameters, DownloadType downloadType)
        {
            using (WebClient client = new WebClient())
            {
                string url = $"{Utility.GetURI(parameters, _baseUrls, _apiKey)}&download_type={Utility.GetDownloadType(downloadType)}";

                return client.DownloadDataTaskAsync(url);
            }
        }

        public byte[] DownloadSeries(TimeSeriesParameters parameters, DownloadType downloadType)
        {
            using (WebClient client = new WebClient())
            {
                string url = $"{Utility.GetURI(parameters, _baseUrls, _apiKey)}&download_type={Utility.GetDownloadType(downloadType)}";

                return client.DownloadData(url);
            }
        }

        public DataSet GetDataSet(TimeSeriesParameters parameters)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            string content = Request(parameters);

            JObject jContent = JObject.Parse(content);

            string dataSetKey = jContent.ContainsKey("dataset_data") ? "dataset_data" : "dataset";

            return JsonConvert.DeserializeObject<DataSet>(jContent[dataSetKey].ToString());
        }

        public async Task<DataSet> GetDataSetAsync(TimeSeriesParameters parameters)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            string content = await RequestAsync(parameters);

            JObject jContent = JObject.Parse(content);

            string dataSetKey = jContent.ContainsKey("dataset_data") ? "dataset_data" : "dataset";

            return JsonConvert.DeserializeObject<DataSet>(jContent[dataSetKey].ToString());
        }

        public DatabaseMetaData GetDatabaseMetaData(TimeSeriesParameters parameters)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            parameters.Metadata = true;

            string content = Request(parameters);

            JObject jContent = JObject.Parse(content);

            return JsonConvert.DeserializeObject<DatabaseMetaData>(jContent["database"].ToString());
        }

        public async Task<DatabaseMetaData> GetDatabaseMetaDataAsync(TimeSeriesParameters parameters)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            parameters.Metadata = true;

            string content = await RequestAsync(parameters);

            JObject jContent = JObject.Parse(content);

            return JsonConvert.DeserializeObject<DatabaseMetaData>(jContent["database"].ToString());
        }

        public DataTable GetDataTable(TablesParameters parameters)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            string content = Request(parameters);

            JObject jContent = JObject.Parse(content);

            return JsonConvert.DeserializeObject<DataTable>(jContent["datatable"].ToString());
        }

        public async Task<DataTable> GetDataTableAsync(TablesParameters parameters)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            string content = await RequestAsync(parameters);

            JObject jContent = JObject.Parse(content);

            return JsonConvert.DeserializeObject<DataTable>(jContent["datatable"].ToString());
        }

        public DataTableMetaData GetDataTableMetaData(TablesParameters parameters)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            parameters.Metadata = true;

            string content = Request(parameters);

            JObject jContent = JObject.Parse(content);

            return JsonConvert.DeserializeObject<DataTableMetaData>(jContent["datatable"].ToString());
        }

        public async Task<DataTableMetaData> GetDataTableMetaDataAsync(TablesParameters parameters)
        {
            parameters.ReturnFormat = ReturnFormat.JSON;

            parameters.Metadata = true;

            string content = await RequestAsync(parameters);

            JObject jContent = JObject.Parse(content);

            return JsonConvert.DeserializeObject<DataTableMetaData>(jContent["datatable"].ToString());
        }

        #endregion Methods
    }
}