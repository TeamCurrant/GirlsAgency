using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using GirlsAgency.Model;
using GirlsAgency.Model.Enums;
using Microsoft.Office.Interop.Excel;

namespace GirlsAgency.Data.FileManipulations
{
    public static class Excel
    {
        public static IEnumerable<Girl> ExportData(string path, string fileName)
        {
            var filePathAndExtention = path + fileName;

            var xlApp = new Application();
            var xlWorkbook = xlApp.Workbooks.Open(Path.GetFullPath(filePathAndExtention));
            var xlWorksheet = (Worksheet)xlWorkbook.Sheets.Item[1];
            var xlRange = xlWorksheet.UsedRange;
            var valueArray = (object[,])xlRange.Value[XlRangeValueDataType.xlRangeValueDefault];

            // Close the Workbook.
            xlWorkbook.Close(false);
            Marshal.ReleaseComObject(xlWorkbook);
            xlApp.Quit();
            Marshal.FinalReleaseComObject(xlApp);

            var girlsCollection = ConvertToCollection(valueArray);

            return girlsCollection;
        }

        private static IEnumerable<Girl> ConvertToCollection(object[,] valueArray)
        {
            var girlsArray = new List<Girl>();

            for (var row = 2; row <= valueArray.GetLength(0); row++)
            {
                var girl = new Girl
                {
                    FirstName = valueArray[row, 1].ToString(),
                    LastName = valueArray[row, 2].ToString(),
                    Age = Convert.ToInt32(valueArray[row, 3]),
                    BreastSizeId = GetBreastSizeType(valueArray[row, 4].ToString()),
                    HairColorId = GetHairColorType(valueArray[row,5].ToString()),
                    PricePerHour = Convert.ToInt32(valueArray[row, 8])
                };

                girlsArray.Add(girl);
            }

            return girlsArray;
        }

        private static int GetBreastSizeType(string brestType)
        {
            var result = Enum.Parse(typeof(BreastSizeEnum), brestType);
            if (result != null)
            {
                return (int) result;
            }

            return 0;
        }

        private static int GetHairColorType(string colorType)
        {
            var result = Enum.Parse(typeof(HairColorEnum), colorType);
            if (result != null)
            {
                return (int)result;
            }

            return 0;
        }
    }
}
