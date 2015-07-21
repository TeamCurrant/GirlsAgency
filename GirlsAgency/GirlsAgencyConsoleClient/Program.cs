using System;
using System.IO.Compression;

namespace GirlsAgencyConsoleClient
{
    class Program
    {

        static void Main()
        {
            //var context = new GirlsAgencyContext();
            //var girl = new Girl()
            //{
            //    FirstName = "Minka",
            //    LastName = "Svirchoka",
            //    Age = 18,
            //    BreastSizeId = (int)BreastSizeEnum.Normal,
            //    HairColorId = (int)HairColorEnum.Blonde,
            //    PricePerHour = 80.0M,
            //    Features = new HashSet<Feature>
            //    {
            //        new Feature {Name = GirlsFeaturesEnum.Felatio.ToString()},
            //        new Feature {Name = GirlsFeaturesEnum.DoggyStyle.ToString()}
            //    }
            //};

            const string zipPath = @"C:\Users\v.indzhev\Desktop\Bunker.zip";
            const string extractPath = @"C:\Users\v.indzhev\Desktop\Bunker\";
            //ZipFile.ExtractToDirectory(zipPath, extractPath);


            var test = GirlsAgency.Data.FileManipulations.Excel.ExportData(@"C:\Users\v.indzhev\Desktop\Bunker\", @"Importer.xlsx");
            foreach (var t in test)
            {
                Console.WriteLine(t);
            }

            //context.Girls.Add(girl);
            //context.SaveChanges();
            //Console.WriteLine(girlsCount);
        }
    }
}
