using System.Collections.Generic;

namespace Quandl
{
    public class TablesParameters
    {
        #region Constructor

        public TablesParameters(string vendorCode, string datatableCode, ReturnFormat returnFormat)
        {
            VendorCode = vendorCode;

            DatatableCode = datatableCode;

            ReturnFormat = returnFormat;
        }

        #endregion Constructor

        #region Properties

        public string VendorCode { get; set; }

        public string DatatableCode { get; set; }

        public ReturnFormat ReturnFormat { get; set; }

        public Dictionary<string, List<string>> RowsFilter { get; set; }

        public List<string> Columns { get; set; }

        public int? PerPage { get; set; }

        public string CursorID { get; set; }

        public bool Metadata { get; set; }

        public bool Export { get; set; }

        #endregion Properties
    }
}