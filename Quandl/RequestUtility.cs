using System;
using System.Collections.Generic;
using System.Linq;

namespace Quandl
{
    public static class RequestUtility
    {
        public static string GetReturnFormat(ReturnFormat returnFormat)
        {
            switch (returnFormat)
            {
                case ReturnFormat.JSON:
                    return "json";

                case ReturnFormat.XML:
                    return "xml";

                case ReturnFormat.CSV:
                    return "csv";

                default:
                    return string.Empty;
            }
        }

        public static string GetOrder(Order order)
        {
            return order == Order.Ascending || order == Order.None ? "asc" : "desc";
        }

        public static string GetCollapse(Collapse collapse)
        {
            switch (collapse)
            {
                case Collapse.Daily:
                    return "daily";

                case Collapse.Weekly:
                    return "weekly";

                case Collapse.Monthly:
                    return "monthly";

                case Collapse.Quarterly:
                    return "quarterly";

                case Collapse.Annual:
                    return "annual";

                default:
                    return "none";
            }
        }

        public static string GetTransform(Transform transform)
        {
            switch (transform)
            {
                case Transform.Diff:
                    return "diff";

                case Transform.RDiff:
                    return "rdiff";

                case Transform.RDiffFrom:
                    return "rdiff_from";

                case Transform.Cumul:
                    return "cumul";

                case Transform.Normalize:
                    return "normalize";

                default:
                    return "none";
            }
        }

        public static string GetDownloadType(DownloadType downloadType)
        {
            return downloadType == DownloadType.Full ? "full" : "partial";
        }

        public static Uri GetURI(TimeSeriesParameters parameters, string apiKey)
        {
            string url = $"{BaseURL.TimeSeriesURL}{parameters.DatabaseCode}";

            if (!string.IsNullOrEmpty(parameters.DatasetCode))
            {
                if (parameters.Metadata.HasValue)
                {
                    url += parameters.Metadata.Value ? $"/{parameters.DatasetCode}/metadata" : $"/{parameters.DatasetCode}/data";
                }
                else
                {
                    url += $"/{parameters.DatasetCode}";
                }
            }

            url += $".{GetReturnFormat(parameters.ReturnFormat)}";

            UriBuilder uriBuilder = new UriBuilder(url);

            uriBuilder.Query = $"api_key={apiKey}";

            if (parameters.Limit.HasValue)
            {
                uriBuilder.Query += $"&limit={parameters.Limit}";
            }

            if (parameters.ColumnIndex.HasValue)
            {
                uriBuilder.Query += $"&column_index={parameters.ColumnIndex}";
            }

            if (parameters.StartDate.HasValue)
            {
                uriBuilder.Query += $"&start_date={parameters.StartDate.Value.ToString("yyyy-MM-dd")}";
            }

            if (parameters.EndDate.HasValue)
            {
                uriBuilder.Query += $"&end_date={parameters.EndDate.Value.ToString("yyyy-MM-dd")}";
            }

            if (parameters.Order != Order.None)
            {
                uriBuilder.Query += $"&order={GetOrder(parameters.Order)}";
            }

            if (parameters.Collapse != Collapse.None)
            {
                uriBuilder.Query += $"&collapse={GetCollapse(parameters.Collapse)}";
            }

            if (parameters.Transform != Transform.None)
            {
                uriBuilder.Query += $"&transform={GetTransform(parameters.Transform)}";
            }

            return uriBuilder.Uri;
        }

        public static Uri GetURI(TablesParameters parameters, string apiKey)
        {
            string url = $"{BaseURL.TablesURL}{parameters.VendorCode}/{parameters.DatatableCode}";

            url += parameters.Metadata ? $"/metadata" : string.Empty;

            url += $".{GetReturnFormat(parameters.ReturnFormat)}";

            UriBuilder uriBuilder = new UriBuilder(url);

            uriBuilder.Query = $"api_key={apiKey}";

            foreach (KeyValuePair<string, List<string>> rowFilter in parameters.RowsFilter)
            {
                if (rowFilter.Value != null && rowFilter.Value.Any())
                {
                    uriBuilder.Query += $"&{rowFilter.Key}=";

                    rowFilter.Value.ToList().ForEach(v => uriBuilder.Query += rowFilter.Value.Last() != v ? $"{v}," : v);
                }
            }

            if (parameters.Columns != null && parameters.Columns.Any())
            {
                uriBuilder.Query += $"&qopts.columns=";

                parameters.Columns.ToList().ForEach(col => uriBuilder.Query += parameters.Columns.Last() != col ? $"{col}," : col);
            }

            if (parameters.PerPage.HasValue)
            {
                uriBuilder.Query += $"&qopts.per_page={parameters.PerPage}";
            }

            if (!string.IsNullOrEmpty(parameters.CursorID))
            {
                uriBuilder.Query += $"&qopts.cursor_id={parameters.CursorID}";
            }

            if (parameters.Export)
            {
                uriBuilder.Query += "&qopts.export=true";
            }

            return uriBuilder.Uri;
        }
    }
}