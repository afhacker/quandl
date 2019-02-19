using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quandl;
using System.Globalization;

namespace QuandlTester
{
    internal class Program
    {
        private static CultureInfo _culture = CultureInfo.InvariantCulture;

        private static string _apiKey;

        private static void Main(string[] args)
        {
            Console.WriteLine("API Key *:");

            _apiKey = Console.ReadLine();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Data Type (TS = Time Series / TA = Tables) OR Exit:");

                string command = Console.ReadLine();

                try
                {
                    if (command.Equals("Exit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        exit = true;
                    }
                    else
                    {
                        if (command.Equals("TS", StringComparison.InvariantCultureIgnoreCase))
                        {
                            GetTimeSeriesData();
                        }
                        else if (command.Equals("TA", StringComparison.InvariantCultureIgnoreCase))
                        {
                            GetTablesData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Unhandled exception occurred");
                    Console.WriteLine($"Message: {ex.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                    Console.WriteLine("--------------------------------------------------");

                    Console.ResetColor();
                }
            }
        }

        private static void GetTimeSeriesData()
        {
            TimeSeriesParameters parameters = new TimeSeriesParameters();

            Console.WriteLine("Database Code *:");

            parameters.DatabaseCode = Console.ReadLine();

            Console.WriteLine("Dataset Code *:");

            parameters.DatasetCode = Console.ReadLine();

            Console.WriteLine("Return Format (JSON, CSV, or XML) *:");

            parameters.ReturnFormat = GetEnum<ReturnFormat>();

            Console.WriteLine("Limit:");

            parameters.Limit = ParseInt(Console.ReadLine());

            Console.WriteLine("Column Index:");

            parameters.ColumnIndex = ParseInt(Console.ReadLine());

            Console.WriteLine("Collapse (Annual, Quarterly, Monthly, Weekly, Daily):");

            parameters.Collapse = GetEnum<Collapse>(Collapse.None);

            Console.WriteLine("Transform (Diff, Cumul, Normalize, RDiff, RDiffFrom):");

            parameters.Transform = GetEnum<Transform>(Transform.None);

            Console.WriteLine("Meta Data (Y / N):");

            parameters.Metadata = ParseBool(Console.ReadLine());

            Console.WriteLine("Order (Ascending / Descending):");

            parameters.Order = GetEnum<Order>(Order.Ascending);

            Console.WriteLine("Start Date (YYYY-MM-dd):");

            parameters.StartDate = ParseDate(Console.ReadLine());

            Console.WriteLine("End Date (YYYY-MM-dd):");

            parameters.EndDate = ParseDate(Console.ReadLine());

            Console.WriteLine("Result:");

            Console.WriteLine(Request.Execute(parameters, _apiKey));
        }

        private static void GetTablesData()
        {
            TablesParameters parameters = new TablesParameters();

            Console.WriteLine("Vendor Code *:");

            parameters.VendorCode = Console.ReadLine();

            Console.WriteLine("Datatable Code *:");

            parameters.DatatableCode = Console.ReadLine();

            Console.WriteLine("Return Format (JSON, CSV, or XML) *:");

            parameters.ReturnFormat = (ReturnFormat)Enum.Parse(typeof(ReturnFormat), Console.ReadLine(), true);

            Console.WriteLine("Per Page:");

            parameters.PerPage = ParseInt(Console.ReadLine());

            Console.WriteLine("CursorID:");

            parameters.CursorID = Console.ReadLine();

            Console.WriteLine("Meta Data (Y / N):");

            parameters.Metadata = ParseBool(Console.ReadLine());

            Console.WriteLine("Export (Y / N):");

            parameters.Export = ParseBool(Console.ReadLine());

            Console.WriteLine("Row Filter (e = end)");

            parameters.RowsFilter = GetRowFilter();

            Console.WriteLine("Columns (Separate with comma):");

            parameters.Columns = GetColumns(Console.ReadLine());

            Console.WriteLine("Result:");

            Console.WriteLine(Request.Execute(parameters, _apiKey));
        }

        private static int? ParseInt(string input) => int.TryParse(input, out int result) ? (int?)result : null;

        private static bool? ParseBool(string input) => !string.IsNullOrEmpty(input) ? (bool?)input.Equals("Y", StringComparison.InvariantCultureIgnoreCase) : null;

        private static DateTime? ParseDate(string input) => !string.IsNullOrEmpty(input) ? (DateTime?)DateTime.ParseExact(input, "yyyy-MM-dd", _culture) : null;

        private static T GetEnum<T>() where T : struct
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (Enum.TryParse(input, out T result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"The input value {input} isn't correcy, retry:");
                }
            }
        }

        private static T GetEnum<T>(T defaultValue) where T : struct
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && Enum.TryParse(input, out T result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }
        }

        private static Dictionary<string, List<string>> GetRowFilter()
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            bool end = false;

            while (!end)
            {
                Console.WriteLine("Column Name:");

                string columnName = Console.ReadLine();

                if (!string.IsNullOrEmpty(columnName))
                {
                    if (columnName.Equals("e", StringComparison.InvariantCultureIgnoreCase))
                    {
                        end = true;
                    }
                    else
                    {
                        Console.WriteLine("Row Values (Separate with comma):");

                        string rowValues = Console.ReadLine();

                        result.Add(columnName, rowValues.Split(',').ToList());
                    }
                }
            }

            return result;
        }

        private static List<string> GetColumns(string input) => !string.IsNullOrEmpty(input) ? input.Split(',').ToList() : null;
    }
}