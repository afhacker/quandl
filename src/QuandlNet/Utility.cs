using System;
using System.Collections.Generic;
using System.Linq;
using QuandlNet.Enums;
using QuandlNet.Models;

namespace QuandlNet
{
    public static class Utility
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

        public static string GetOrder(Order order) => order == Order.Ascending || order == Order.None ? "asc" : "desc";

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

        public static string GetDownloadType(DownloadType downloadType) => downloadType == DownloadType.Full ? "full" : "partial";

        public static Uri GetURI(TimeSeriesParameters parameters, BaseUrls baseUrls, string apiKey)
        {
            string url = $"{baseUrls.TimeSeriesUrl}{parameters.DatabaseCode}";

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

            string uriQuery = $"api_key={apiKey}";

            if (parameters.Limit.HasValue)
            {
                uriQuery += $"&limit={parameters.Limit}";
            }

            if (parameters.ColumnIndex.HasValue)
            {
                uriQuery += $"&column_index={parameters.ColumnIndex}";
            }

            if (parameters.StartDate.HasValue)
            {
                uriQuery += $"&start_date={parameters.StartDate.Value.ToString("yyyy-MM-dd")}";
            }

            if (parameters.EndDate.HasValue)
            {
                uriQuery += $"&end_date={parameters.EndDate.Value.ToString("yyyy-MM-dd")}";
            }

            if (parameters.Order != Order.None)
            {
                uriQuery += $"&order={GetOrder(parameters.Order)}";
            }

            if (parameters.Collapse != Collapse.None)
            {
                uriQuery += $"&collapse={GetCollapse(parameters.Collapse)}";
            }

            if (parameters.Transform != Transform.None)
            {
                uriQuery += $"&transform={GetTransform(parameters.Transform)}";
            }

            uriBuilder.Query = uriQuery;

            return uriBuilder.Uri;
        }

        public static Uri GetURI(TablesParameters parameters, BaseUrls baseUrls, string apiKey)
        {
            string url = $"{baseUrls.TablesUrl}{parameters.VendorCode}/{parameters.DatatableCode}";

            url += parameters.Metadata.HasValue && parameters.Metadata.Value ? $"/metadata" : string.Empty;

            url += $".{GetReturnFormat(parameters.ReturnFormat)}";

            UriBuilder uriBuilder = new UriBuilder(url);

            string uriQuery = $"api_key={apiKey}";

            if (parameters.RowsFilter != null && parameters.RowsFilter.Any())
            {
                foreach (KeyValuePair<string, List<string>> rowFilter in parameters.RowsFilter)
                {
                    if (rowFilter.Value != null && rowFilter.Value.Any())
                    {
                        uriQuery += $"&{rowFilter.Key}=";

                        rowFilter.Value.ToList().ForEach(v => uriQuery += rowFilter.Value.Last() != v ? $"{v}," : v);
                    }
                }
            }

            if (parameters.Columns != null && parameters.Columns.Any())
            {
                uriQuery += $"&qopts.columns=";

                parameters.Columns.ToList().ForEach(col => uriQuery += parameters.Columns.Last() != col ? $"{col}," : col);
            }

            if (parameters.PerPage.HasValue)
            {
                uriQuery += $"&qopts.per_page={parameters.PerPage}";
            }

            if (!string.IsNullOrEmpty(parameters.CursorID))
            {
                uriQuery += $"&qopts.cursor_id={parameters.CursorID}";
            }

            if (parameters.Export.HasValue && parameters.Export.Value)
            {
                uriQuery += "&qopts.export=true";
            }

            uriBuilder.Query = uriQuery;

            return uriBuilder.Uri;
        }
    }
}