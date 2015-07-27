using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using GirlsAgency.Data;
using GirlsAgency.Model;
using GirlsAgency.Model.Enums;
using GirlsAgency.Repository.Repositories;
using Microsoft.Office.Interop.Excel;
using GirlsAgency.MySQL.Data;

namespace GirlsAgency.Repository.FileManipulations
{
    public static class Excel
    {
        public static void GetRecords(string filePath, string type)
        {
            var page = (type == "Girls") ? 1 : 2;
            var xlApp = new Application();
            var xlWorkbook = xlApp.Workbooks.Open(Path.GetFullPath(filePath));
            var xlWorksheet = (Worksheet)xlWorkbook.Sheets.Item[page];
            var xlRange = xlWorksheet.UsedRange;

            var data = (object[,])xlRange.Value[XlRangeValueDataType.xlRangeValueDefault];

            // Close the Workbook.
            xlWorkbook.Close(false);
            Marshal.ReleaseComObject(xlWorkbook);
            xlApp.Quit();
            Marshal.FinalReleaseComObject(xlApp);

            var kuf = ConvertToCollection(data, type);
            if (type == "Girls")
            {
                ImportGirlsToDatabase((IEnumerable<Girl>) kuf);
            }
            else
            {
                ImportCustomersToDatabase((IEnumerable<Customer>) kuf);
            }
        }

        private static IEnumerable ConvertToCollection(object[,] valueArray, string type)
        {
            return type == "Girls" ? GetGirls(valueArray) : GetCustomer(valueArray);
        }

        private static IEnumerable GetGirls(object[,] array)
        {
            var girlsArray = new List<Girl>();

            for (var row = 2; row <= array.GetLength(0); row++)
            {
                var girl = new Girl
                {
                    FirstName = array[row, 1].ToString(),
                    LastName = array[row, 2].ToString(),
                    Age = Convert.ToInt32(array[row, 3]),
                    BreastSizeId = GetBreastSizeType(array[row, 4].ToString()),
                    HairColorId = GetHairColorType(array[row, 5].ToString()),
                    CityId = 1,
                    CountyId = 1,
                    PricePerHour = Convert.ToInt32(array[row, 8])
                };

                girlsArray.Add(girl);
            }

            return girlsArray;
        }

        private static IEnumerable GetCustomer(object[,] array)
        {
            var customerArray = new List<Customer>();

            for (var row = 2; row <= array.GetLength(0); row++)
            {
                var girl = new Customer
                {
                    FirstName = array[row, 1].ToString(),
                    LastName = array[row, 2].ToString(),
                    CityId = Convert.ToInt32(array[row, 3]),
                    CountryId = Convert.ToInt32(array[row, 4])
                };

                customerArray.Add(girl);
            }

            return customerArray;
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

        private static void ImportGirlsToDatabase(IEnumerable<Girl> list)
        {
            var sqlRepo = new GenericRepository<Girl>(new GirlsAgencyContext());

            var mySqlRepo = new GenericRepository<Girl>(new MySQLContext());

            foreach (var girl in list)
            {
                sqlRepo.Add(girl);
                mySqlRepo.Add(girl);
            }

            sqlRepo.SaveChanges();
            mySqlRepo.SaveChanges();
        }

        private static void ImportCustomersToDatabase(IEnumerable<Customer> list)
        {
            var sqlRepo = new GenericRepository<Customer>(new GirlsAgencyContext());

            var mySqlRepo = new GenericRepository<Customer>(new MySQLContext());

            foreach (var customer in list)
            {
                sqlRepo.Add(customer);
                mySqlRepo.Add(customer);
            }

            sqlRepo.SaveChanges();
            mySqlRepo.SaveChanges();
        }
    }
}
