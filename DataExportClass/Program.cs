using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataExportClass
{
    class Program
    {
        public class Employee
        {
            public string Name { get; set; }
            public string Date { get; set; }
            public string Mobile { get; set; }
            public string MerchantControlLabel { get; set; }
            public string FormValue { get; set; }
        }

        static void Main(string[] args)
        {
            var employees = new List<Employee>()
            {
                new Employee
                {
                    Date =  "2020-04-29",
                    Name = "Roshan",
                    Mobile = "9558243312",
                    MerchantControlLabel = "Date Of Birth",
                    FormValue = "2010-05-26"
                },
                new Employee
                {
                    Date =  "2020-04-29",
                    Name = "Roshan",
                    Mobile = "9558243312",
                    MerchantControlLabel = "Recent exposure to Covid-19 Patient OR Family History",
                    FormValue = "No"
                },new Employee
                {
                    Date =  "2020-04-29",
                    Name = "Roshan",
                    Mobile = "9558243312",
                    MerchantControlLabel = "Reason for Visit",
                    FormValue = "Burning Urination"
                },new Employee
                {
                    Date =  "2020-04-29",
                    Name = "Roshan",
                    Mobile = "9558243312",
                    MerchantControlLabel = "Address",
                    FormValue = "Address of patient"
                },
            };
            ExportData.ExportCsv(employees, "employees_Dynamic");
        }


        public static class ExportData
        {
            public static void ExportCsv<T>(List<T> genericList, string fileName)
            {
                var sb = new StringBuilder();
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var finalPath = Path.Combine(basePath, fileName + ".csv");
                var header = "";
                var info = typeof(T).GetProperties();
                if (!File.Exists(finalPath))
                {
                    var file = File.Create(finalPath);
                    file.Close();
                    header = string.Join(",", typeof(T).GetProperties().Select(x => x.Name));
                    sb.AppendLine(header);
                    TextWriter sw = new StreamWriter(finalPath, true);
                    sw.Write(sb.ToString());
                    sw.Close();
                }
                foreach (var obj in genericList)
                {
                    sb = new StringBuilder();
                    var line = "";
                    line = string.Join(",", typeof(T).GetProperties().Select(x => x.GetValue(obj, null)));
                    sb.AppendLine(line);
                    TextWriter sw = new StreamWriter(finalPath, true);
                    sw.Write(sb.ToString());
                    sw.Close();
                }
            }
        }
    }
}
