namespace GirlsAgencyConsoleClient
{
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Excel;

    static class ExcelReader
    {
        public static object[,] GetExcelInfo()
        {
            const string strNewPath = @"C:\Users\v.indzhev\Desktop\Bunker\Importer.xlsx";

            // Reference to Excel Application.
            var xlApp = new Application();

            // Open the Excel file.
            // You have pass the full path of the file.
            // In this case file is stored in the Bin/Debug application directory.
            var xlWorkbook = xlApp.Workbooks.Open(Path.GetFullPath(strNewPath));

            // Get the first worksheet.
            var xlWorksheet = (Worksheet)xlWorkbook.Sheets.Item[1];

            // Get the range of cells which has data.
            var xlRange = xlWorksheet.UsedRange;

            // Get an object array of all of the cells in the worksheet with their values.
            var valueArray = (object[,])xlRange.Value[XlRangeValueDataType.xlRangeValueDefault];

            // Close the Workbook.
            xlWorkbook.Close(false);
            Marshal.ReleaseComObject(xlWorkbook);
            xlApp.Quit();
            Marshal.FinalReleaseComObject(xlApp);


            return valueArray;
        }
    }
}
