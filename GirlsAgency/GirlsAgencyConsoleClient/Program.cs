﻿using System;
using System.Linq;
using GirlsAgency.Data;
using GirlsAgency.Model;
using GirlsAgency.Repository.FileManipulations;
using GirlsAgency.Repository.Repositories;
using GirlsAgencyOracle.Data;

namespace GirlsAgencyConsoleClient
{
    class Program
    {

        static void Main()
        {
            
            //var SqlServerGirslRepo = new GenericRepository<Girl>(new GirlsAgencyContext());
            //Console.WriteLine(SqlServerGirslRepo.GetAll().Count());

            //var girl = new Girl()
            //{
            //     Age = 20,
            //}








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

            //const string zipPath = @"C:\Users\v.indzhev\Desktop\Bunker.zip";
            //const string extractPath = @"C:\Users\v.indzhev\Desktop\Bunker\";
            ////ZipFile.ExtractToDirectory(zipPath, extractPath);


            //var test = Excel.GetRecords(@"C:\Users\v.indzhev\Desktop\Bunker\Importer.xlsx", "Girl");
            //foreach (var t in test)
            //{
            //    Console.WriteLine(t);
            //}

            //context.Girls.Add(girl);
            //context.SaveChanges();
            //Console.WriteLine(girlsCount);

            //var context = new GirlsAgencyContext();
            //var orders = XML.Read(@"C:\Users\v.indzhev\Desktop\kovri.xml");
            //foreach (var order in orders)
            //{
            //    context.Orders.Add(order);
            //}

            //context.SaveChanges();

            //var context = new GirlsAgencyContext();
            //Console.WriteLine(context.Girls.Count());

            //var context2 = new OracleContext();
            //Console.WriteLine(context2.Girls.Count());
            //context.SaveChanges();
            //var oracle = new OracleContext();
            //var sqlServer = new GirlsAgencyContext();
            //var oralcleServer = new OracleContext();

            //var GirlsAgencySqlSystem = new GenericRepository<Girl>(sqlServer);
            //var GirlAgencyOracleSystem = new GenericRepository<Girl>(oralcleServer);

            //int a =  GirlsAgencySqlSystem.GetAll().Count();
            //int b = GirlAgencyOracleSystem.GetAll().Count();
            //Console.WriteLine(b);

            //Console.WriteLine(a);

            //Console.WriteLine();


            //var controller = new RepositoryController(oracle, sqlServer);

            //var girl = new Girl
            //{
            //    FirstName = "Minka",
            //    LastName = "Svirchoka",
            //    Age = 18,
            //    BreastSizeId = (int)BreastSizeEnum.Normal,
            //    HairColorId = (int)HairColorEnum.Blonde,
            //    PricePerHour = 80.0M

            //};


            // girlRepoSqlServer.Add(girl);
            //GirlAgencyOracleSystem.Add(girl);

            //GirlAgencyOracleSystem.SaveChanges();

            //var gir = GirlAgencyOracleSystem.GetAll().First();
            //Console.WriteLine(gir.FirstName);


            // Console.WriteLine(GirlAgencyOracleSystem.GetEntityAsJson(gir));

            //var json= GirlsAgencySqlSystem.GetJson();
            //var jsonSqlServer = GirlsAgencySqlSystem.GetJson();

            //Console.WriteLine(json);

            //Console.WriteLine(json);
            //var girl2 = new Girl()
            //{
            //    FirstName = "kur",
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


            //ICollection<Girl> girls = new List<Girl>();
            //girls.Add(girl);
            //girls.Add(girl2);

            //controller.Test(girls);

            var cont = new GirlsAgencyContext();
            Console.WriteLine(cont.Customers.Count());


            var aaa = new GenericRepository<Country>(new GirlsAgencyContext());
            aaa.Add(new Country { Name = "Kur" });
            aaa.SaveChanges();
        }
    }
}
