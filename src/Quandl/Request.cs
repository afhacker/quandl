using System.Net;
using System.Threading.Tasks;

namespace Quandl
{
    public static class Request
    {
        #region Methods

        public static Task<string> ExecuteAsync(TimeSeriesParameters parameters, string apiKey)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadStringTaskAsync(RequestUtility.GetURI(parameters, apiKey));
            }
        }

        public static Task<string> ExecuteAsync(TablesParameters parameters, string apiKey)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadStringTaskAsync(RequestUtility.GetURI(parameters, apiKey));
            }
        }

        public static string Execute(TimeSeriesParameters parameters, string apiKey)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(RequestUtility.GetURI(parameters, apiKey));
            }
        }

        public static string Execute(TablesParameters parameters, string apiKey)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(RequestUtility.GetURI(parameters, apiKey));
            }
        }

        public static Task<byte[]> DownloadTimeSeriesDatasetAsync(TimeSeriesParameters parameters, DownloadType downloadType, string apiKey)
        {
            using (WebClient client = new WebClient())
            {
                string url = $"{RequestUtility.GetURI(parameters, apiKey)}&download_type={RequestUtility.GetDownloadType(downloadType)}";

                return client.DownloadDataTaskAsync(url);
            }
        }

        public static byte[] DownloadTimeSeriesDataset(TimeSeriesParameters parameters, DownloadType downloadType, string apiKey)
        {
            using (WebClient client = new WebClient())
            {
                string url = $"{RequestUtility.GetURI(parameters, apiKey)}&download_type={RequestUtility.GetDownloadType(downloadType)}";

                return client.DownloadData(url);
            }
        }

        #endregion Methods
    }
}