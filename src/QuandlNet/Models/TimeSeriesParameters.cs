using System;
using QuandlNet.Enums;

namespace QuandlNet.Models
{
    public class TimeSeriesParameters
    {
        #region Properties

        public string DatabaseCode { get; set; }

        public string DatasetCode { get; set; }

        public ReturnFormat ReturnFormat { get; set; }

        public int? Limit { get; set; }

        public int? ColumnIndex { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Order Order { get; set; }

        public Collapse Collapse { get; set; }

        public Transform Transform { get; set; }

        public bool? Metadata { get; set; }

        #endregion Properties
    }
}