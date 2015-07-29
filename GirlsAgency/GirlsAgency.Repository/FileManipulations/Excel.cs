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

using System.IO.Compression;
using System.Runtime.CompilerServices;
using GirlsAgency.Repository.Contracts;
using GirlsAgencyOracle;
using GirlsAgencyOracle.Data;

namespace GirlsAgency.Repository.FileManipulations
{
    public static class Excel
    {
        public static void GetRecords(string filePath, string type, [CallerMemberName]string memberName = "")
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
            

            if (memberName == "ReadZip")
            {

                if (type == "Girls")
                {
                    ImportGirlsToDatabase((IEnumerable<Girl>) kuf, new GenericRepository<Girl>(new GirlsAgencyContext()));
                }
                else
                {
                    ImportCustomersToDatabase((IEnumerable<Customer>) kuf, new GenericRepository<Customer>(new GirlsAgencyContext()));
                }
            }
            else
            {
                if (type == "Girls")
                {
                    ImportGirlsToDatabase((IEnumerable<Girl>) kuf, new GenericRepository<Girl>(new OracleContext()));
                }
                else
                {
                    ImportCustomersToDatabase((IEnumerable<Customer>) kuf, new GenericRepository<Customer>(new OracleContext()));
                }
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

        private static void ImportGirlsToDatabase(IEnumerable<Girl> list, IGenericRepository<Girl> sqlRepo)
        {
            
            foreach (var girl in list)
            {
                sqlRepo.Add(girl);
            }

            sqlRepo.SaveChanges();
        }

        private static void ImportCustomersToDatabase(IEnumerable<Customer> list, IGenericRepository<Customer> repo)
        {
            foreach (var customer in list)
            {
                repo.Add(customer);
               // mySqlRepo.Add(customer);
            }

            repo.SaveChanges();
           // mySqlRepo.SaveChanges();
        }

        public static string ReadZip(string type)
        {
            const string zipPath = @"D:\bunker\bunker.zip";
            const string extractPath = @"D:\bunker\";
            File.Delete(@"D:\bunker\Importer.xlsx");
            ZipFile.ExtractToDirectory(zipPath, extractPath);
            GetRecords(extractPath + "Importer.xlsx", type);
            
            return "";
        }



        //here is the exporter KUR



















    }
}
