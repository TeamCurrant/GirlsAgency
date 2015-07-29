using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using GirlsAgency.SQLite.Data;
using NetOffice.ExcelApi.Enums;
using Excel = NetOffice.ExcelApi;

namespace GirlsAgencyConsoleClient.Exporters
{
    public class ExcelExporter
    {
        //public ExcelExporter(string txtBox)
        //{
        //    Console.SetOut(new TextBoxWriter(txtBox));
        //}

        public void GenerateReport()
        {
            var excelApplication = new Excel.Application();

            excelApplication.Workbooks.Add();

            excelApplication.DisplayAlerts = false;

            var style = excelApplication.ActiveWorkbook.Styles.Add("NewStyle");
            style.Font.Name = "Verdana";
            style.Font.Size = 12;
            style.Font.Bold = true;

            //Get active worksheet
            var sheet = (Excel.Worksheet)excelApplication.ActiveSheet;

            AddColumnNames(sheet);

            AddExcelHeadingText(sheet);

            AddDataRows(sheet);

            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "FinancialReport");
            excelApplication.ActiveWorkbook.SaveAs(filePath, Missing.Value, Missing.Value, Missing.Value, false,
                                          false, XlSaveAsAccessMode.xlExclusive);

            //CleanUp
            excelApplication.ActiveWorkbook.Close();
            excelApplication.Quit();
            excelApplication.Dispose();
        }

        private static void AddColumnNames(Excel.Worksheet sheet)
        {
            string[] tempHeadingArray =
            {
                "FirstName",
                "LastName",
                "Income",
                "Tax",
                "Total Income"
            };

            var columnNameRange = sheet.get_Range(sheet.Cells[3, 1], sheet.Cells[3, tempHeadingArray.Length]);
            columnNameRange.Style = "NewStyle";
            columnNameRange.Font.Size = 10;
            columnNameRange.Value = tempHeadingArray;
            columnNameRange.UseStandardWidth = true;
            columnNameRange.ColumnWidth = 14;
            columnNameRange.WrapText = true;
        }

        private static void AddExcelHeadingText(Excel.Worksheet sheet)
        {
            //Apply styling to heading text
            sheet.Cells[1, 1].Value = "Girl Agency Financial Report";
            sheet.Cells[1, 1].Font.Name = "Impact";
            sheet.Cells[1, 1].Font.Underline = true;
            sheet.Cells[1, 1].Font.Size = 14;
        }

        private static string[][] GetData()
        {
           // var db = new SQLiteDatabase(@"..\..\ProductsTaxes.sqlite");
            var db = new GirlsTaxesEntities();
            DataTable table;
            //String query = "select * from ProductTaxes";
            //table = db.GetDataTable(query);

            List<GirlsTax> ptList = db.GirlsTaxes.Select(n=>n).ToList();

            var mysqlContext = new GirlAgencyMySql.Data.MySql();

            var girlsExpences = mysqlContext.Orders.Select(v => new
            {
                FirstName = v.Girl.FirstName,
                LastName = v.Girl.LastName,
                Income = v.Girl.PricePerHour * v.Duration

                //Expense = v.Expenses.Select(e => e.Money).FirstOrDefault(),
                //Income = mysqlContext.Products.Where(p => p.VendorId == v.Id).Select(p => p.Income).FirstOrDefault(),
                //Products = mysqlContext.Products.Where(p => p.VendorId == v.Id).Select(p => p.Id)
            }).ToList();

            List<string[]> dataList = new List<string[]>();

            for (int i = 0; i < girlsExpences.Count; i++)
            {
                decimal vendorTax = 0;
                foreach (var product in girlsExpences[i].FirstName)
                {
                    foreach (var productTax in ptList)
                    {
                        if (productTax.id == product)
                        {
                            vendorTax += Convert.ToDecimal(productTax.Tax) / 100 * girlsExpences[i].Income;
                        }
                    }
                }

                string[] dataObj =
                {
                    girlsExpences[i].FirstName.ToString(),
                    girlsExpences[i].Income.ToString(),
                    //(girlsExpences[i]. ?? 0).ToString(),
                    vendorTax.ToString(),
                    //(girlsExpences[i].Income - (girlsExpences[i].Expense ?? 0) - vendorTax).ToString()
                };

                dataList.Add(dataObj);
            }


            return dataList.ToArray();
        }

        private static void AddDataRows(Excel.Worksheet sheet)
        {
            sheet.Name = "Financial report";
            var reportResult = GetData();
            var value = new string[reportResult.Length, 5];
            for (var row = 0; row < reportResult.Length; row++)
            {
                Console.WriteLine("Importing:\n---------------");
                for (int col = 0; col < reportResult[row].Length; col++)
                {
                    value[row, col] = reportResult[row][col];
                    Console.WriteLine(reportResult[row][col]);
                }
            }
            var range = sheet.Range(sheet.Cells[4, 1],
                sheet.Cells[reportResult.Length + 3, reportResult[1].Length]);
            range.Value = value;
            Console.WriteLine("Ready!!!");
        }

    }
}