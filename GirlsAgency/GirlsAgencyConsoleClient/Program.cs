﻿using System;
using System.Data.SQLite;
using System.Linq;
using GirlsAgency.Data;
using GirlsAgency.Model;
using GirlsAgency.Repository.Repositories;
using GirlsAgencyOracle.Data;
using GirlsAgency.Repository.FileManipulations;
using GirlsAgency.SQLite.Data;
using GirlsAgencyConsoleClient.Engines;
using iTextSharp.text.xml.simpleparser;

namespace GirlsAgencyConsoleClient
{
    class Program
    {

        static void Main()
        {


            //var kur = new GirlAgencyMySql.Data.MySql();
            //Console.WriteLine(kur.Customers.Count());
            //var ctx = new OracleContext();

            //Console.WriteLine(ctx.Girls.Count());//

           // var mySql = new GirlAgencyMySql.Data.MySql();
           // Console.WriteLine(mySql.Customers.Count());

            while (true)
            {
                string command = Console.ReadLine();
                var dispatchedCommand = CommandEngine.Dispatch(command);
                CommandEngine.Execute(dispatchedCommand);
            }

            //var sqllite = new GirlsTaxesEntities();
            //Console.WriteLine(sqllite.GirlsTaxes.Count());

            //Exporters.PDFExporter.ExportGirlsReport("01.01.2015", "01.01.2016");
            //Exporters.XMLExporter.ExportCitiesReport("01.01.2015", "01.01.2016");



            // //zemi taq moma i i sloji procent
            // string firstName = "Minka";
            // string lastName = "Svirchoka";


            ////need to change database 

            // var girlTaxesContext = new GirlsTaxesEntities();
            // Console.WriteLine(girlTaxesContext.GirlsTaxes.Count());


            // var mySqlGrilRepo = new GenericRepository<Girl>(new GirlsAgencyContext());


            // var girl = mySqlGrilRepo.Search(g => g.FirstName == firstName && g.LastName == lastName).FirstOrDefault();

            // //Console.WriteLine(girl.FirstName);

            // //add  tax for the bitch

            // int tax = 20;




            // girlTaxesContext.GirlsTaxes.Add(
            //     new GirlsTax()
            //     {

            //         GirlName = girl.FirstName + " " + girl.LastName,
            //         Tax = tax

            //     });

            // girlTaxesContext.SaveChanges();

            // Console.WriteLine(girlTaxesContext.GirlsTaxes.Count());










//<<<<<<< HEAD

//            //var SqlServerGirslRepo = new GenericRepository<Girl>(new GirlsAgencyContext());
//            //Console.WriteLine(SqlServerGirslRepo.GetAll().Count());
//=======

            //var context = new GirlsAgencyContext();

            //Console.WriteLine(context.Countries.Count());

            //Exporters.PDFExporter.ExportGirlsReport(new DateTime(2015, 1, 1), new DateTime(2016, 1, 1));


            //var sqlServerGirslRepo = new GenericRepository<Girl>(new GirlsAgencyContext());



            //Console.WriteLine(sqlServerGirslRepo.GetAll().Count());

            //var girl = new Girl()
            //{
            //    BreastSizeId = 1,
            //    Age = 20,
            //    CountyId = 2,
            //    FirstName = "Minka",
            //    LastName = "Svirkata",
            //    HairColorId = 4,
            //    CityId = 1,
            //    PricePerHour = 2489M
            //};

            //sqlServerGirslRepo.Add(girl);
            //sqlServerGirslRepo.SaveChanges();

            //var repo = new GenericRepository<Girl>(new GirlsAgencyContext());

            // Excel.GetRecords("E:\\fuckoff\\GirlsAgency\\Importer.xlsx", "Girls");

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
            //var test = GirlsAgency.Data.FileManipulations.Excel.ExportData(@"C:\Users\v.indzhev\Desktop\Bunker\", @"Importer.xlsx");
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
            //XML.ReadXML(@"C:\Users\v.indzhev\Desktop\", @"kovri.xml");



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

            //var cont = new GirlsAgencyContext();
            //Console.WriteLine(cont.Customers.Count());


            //var aaa = new GenericRepository<Country>(new GirlsAgencyContext());
            //aaa.Add(new Country { Name = "Kur" });
            //aaa.SaveChanges();

            // var ctx = new MySQLContext();

            //ctx.Orders.ToList();

            // ctx.SaveChanges();
        }
    }
}
