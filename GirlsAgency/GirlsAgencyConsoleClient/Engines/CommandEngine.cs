using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Script.Serialization;
using GirlsAgency.Data;
using GirlsAgency.Model;
using GirlsAgency.Model.Enums;
using GirlsAgency.Repository.FileManipulations;
using GirlsAgency.Repository.Repositories;
using GirlsAgency.SQLite.Data;
using GirlsAgencyConsoleClient.Exporters;
using GirlAgencyMySql.Data;
using GirlsAgency.Repository.Contracts;
using MySql.Data.MySqlClient.Memcached;
using MySql = GirlAgencyMySql.Data.MySql;


namespace GirlsAgencyConsoleClient.Engines
{
    public static class CommandEngine
    {
        public static string[] Dispatch(string command)
        {
            return command.Split(' ');
        }

        public static void Execute(string[] command)
        {
            switch (command[0])
            {
                case "readzip":
                    Excel.ReadZip(command[1]);
                    break;
                case "readxml":
                    XML.Read(command[1]);
                    break;
                case "readoracle":
                    Excel.GetRecords(command[1], command[2]);
                    break;
                case "exportxml":
                    XML.ExportCitiesReport(command[1], command[2]);
                    break;
                case "exportpdf":
                    PDF.Export(command[1], command[2]);
                    break;
                case "exportjson":
                    printJSON(command[1]);
                    break;
                case "kur":
                    // TODO 

                    ExportToMysql();
                    break;
                case "exportexcel":
                    // TODO call 
                    break;
                case "addtax": AddTaxToGirl(command[1], command[2], int.Parse(command[3]));
                    break;

                case "exit": Environment.Exit(0);
                    break;

                default: throw new ArgumentException("Invalid command");
            }
        }

        private static void ExportToMysql()
        {
            var mysql = new GirlAgencyMySql.Data.MySql();
            //mysql.Database.ExecuteSqlCommand("TURNCATE TABLE['Girls']");
            var sqlGirlsRepo = new GenericRepository<Girl>(new GirlsAgencyContext());
            var sqlCountriesRepo = new GenericRepository<Country>(new GirlsAgencyContext());
            var sqlCitiesRepo = new GenericRepository<City>(new GirlsAgencyContext());
            var sqlClientsRepo = new GenericRepository<Customer>(new GirlsAgencyContext());
            var sqlOrdersRepo = new GenericRepository<Order>(new GirlsAgencyContext());

            var mySqlGirlsRepo = new GenericRepository<Girl>(new GirlAgencyMySql.Data.MySql());
            var mySqlCountriesRepo = new GenericRepository<Country>(new GirlAgencyMySql.Data.MySql());
            var mySqlCitiesRepo = new GenericRepository<City>(new GirlAgencyMySql.Data.MySql());
            var mySqlClientsRepo = new GenericRepository<Customer>(new GirlAgencyMySql.Data.MySql());
            var mysSqlOrdersRepo = new GenericRepository<Order>(new GirlAgencyMySql.Data.MySql());


            //sqlCountriesRepo.GetAll().
            //    ToList().ForEach(
            //    (n => mySqlCountriesRepo.Add(n)));
            //sqlCitiesRepo.GetAll().ForEachAsync(n => mySqlCitiesRepo.Add(n));
            //sqlGirlsRepo.GetAll().ForEachAsync(n => mySqlGirlsRepo.Add(n));
            //sqlClientsRepo.GetAll().ForEachAsync(n => mySqlClientsRepo.Add(n));
            //sqlOrdersRepo.GetAll().ForEachAsync(n => mysSqlOrdersRepo.Add(n));

            //  mySqlCitiesRepo.GetAll().ForEachAsync(n=> Console.WriteLine(n.Name));

            ExportCountriesFromMSSqlToMySql(sqlCountriesRepo, mySqlCountriesRepo);
            ExportGirlsFromMSSqlToMySql();
            ExportCitiesFromMSSqlToMySQL(sqlCitiesRepo, mySqlCitiesRepo);
            ExportCustomerFromMSSqlToMySQL();
            ExportOrdersFromMSSqlToMySql(sqlOrdersRepo, mysSqlOrdersRepo);


            //ExportGirlsFromMSSqlToMySql(sqlGirlsRepo, mySqlGirlsRepo);


        }

        private static void ExportOrdersFromMSSqlToMySql(GenericRepository<Order> sqlOrdersRepo, GenericRepository<Order> mysSqlOrdersRepo)
        {
            var girlsMysql = new GenericRepository<Girl>(new GirlAgencyMySql.Data.MySql());
            var customersMysq = new GenericRepository<Customer>(new GirlAgencyMySql.Data.MySql());
            foreach (var orderFromSql in sqlOrdersRepo.GetAll().ToList())
            {
                //Console.WriteLine(orderFromSql.);
                var order = new Order()
                {
                    GirlId = 
                        girlsMysql
                            .GetAll()
                            .FirstOrDefault(g => g.FirstName == orderFromSql.Girl.FirstName && g.LastName == orderFromSql.Girl.LastName).Id,
                    CustomerId = 
                        customersMysq
                            .GetAll()
                            .FirstOrDefault(c => c.FirstName == orderFromSql.Customer.FirstName &&
                                    c.LastName == orderFromSql.Customer.LastName).Id,
                    Duration = orderFromSql.Duration,
                    Date = orderFromSql.Date
                };

                mysSqlOrdersRepo.Add(order);
            }

            mysSqlOrdersRepo.SaveChanges();
        }

        private static void ExportCustomerFromMSSqlToMySQL()
        {
            var mssqlClients = new GenericRepository<Customer>(new GirlsAgencyContext());
            var girlsMySql = new GenericRepository<Girl>(new GirlAgencyMySql.Data.MySql());
            var mysqlClients = new GenericRepository<Customer>(new GirlAgencyMySql.Data.MySql());
            foreach (var mssqlCustomer in mssqlClients.GetAll().ToList())
            {
                var customer = new Customer()
                {
                    CityId = mssqlCustomer.CityId,
                    CountryId = mssqlCustomer.CountryId,
                    FirstName = mssqlCustomer.FirstName,
                    LastName = mssqlCustomer.LastName,
                    Girls = GetGirls(mssqlCustomer, girlsMySql)
                };

                mysqlClients.Add(customer);
            }

            mysqlClients.SaveChanges();
        }

        private static ICollection<Girl> GetGirls(Customer mssqlCustomer, GenericRepository<Girl> girlsMySql)
        {
            var girls = new List<Girl>();
            foreach (var girl in mssqlCustomer.Girls)
            {
                var girlInDb = girlsMySql
                    .GetAll()
                    .Where(n => n.FirstName == girl.FirstName && n.LastName == girl.LastName)
                    .FirstOrDefault();

                girls.Add(girlInDb);
            }

            return girls;
        }


        private static void ExportGirlsFromMSSqlToMySql()
        {
            var mssqlFeatures = new GenericRepository<Feature>(new GirlsAgencyContext());
            var mysllFeatures = new GenericRepository<Feature>(new GirlAgencyMySql.Data.MySql());

            foreach (var mssqlFeature in mssqlFeatures.GetAll().ToList())
            {
                var feature = new Feature()
                {
                    Name = mssqlFeature.Name
                };

                mysllFeatures.Add(feature);
            }

            mysllFeatures.SaveChanges();
        }

        private static void ExportGirlsFromMSSqlToMySql(GenericRepository<Girl> sqlGirlsRepo, GenericRepository<Girl> mySqlGirlsRepo)
        {
            var girlsFromMSsql = sqlGirlsRepo.GetAll().ToList();
            foreach (var girlFromMSsql in girlsFromMSsql.ToList())
            {
                var girl = new Girl()
                {
                    FirstName = girlFromMSsql.FirstName,
                    LastName = girlFromMSsql.LastName,
                    Age = girlFromMSsql.Age,
                    BreastSizeId = girlFromMSsql.BreastSizeId,
                    HairColorId = girlFromMSsql.HairColorId,
                    CityId = girlFromMSsql.CityId,
                    PricePerHour = girlFromMSsql.PricePerHour,
                    Features = girlFromMSsql.Features,
                    CountyId = girlFromMSsql.CountyId,
                    // City = girlFromMSsql.City,
                    // Country = girlFromMSsql.Country
                };
                mySqlGirlsRepo.Add(girl);
                mySqlGirlsRepo.SaveChanges();
            }
        }

        private static void ExportCitiesFromMSSqlToMySQL(GenericRepository<City> sqlCitiesRepo, GenericRepository<City> mySqlCitiesRepo)
        {
            var mysqlCountries = new GenericRepository<Country>(new GirlAgencyMySql.Data.MySql());
            var citiesFromMSsql = sqlCitiesRepo.GetAll().ToList();
            foreach (var cityFromMSsql in citiesFromMSsql.ToList())
            {
                var city = new City()
                {
                    Name = cityFromMSsql.Name,
                    CountryId = mysqlCountries.
                        GetAll()
                        .FirstOrDefault(n => n.CountryId == cityFromMSsql.CountryId).CountryId
                };
                mySqlCitiesRepo.Add(city);
                mySqlCitiesRepo.SaveChanges();
            }
        }

        private static void ExportCountriesFromMSSqlToMySql(GenericRepository<Country> sqlCountriesRepo, GenericRepository<Country> mySqlCountriesRepo)
        {
            var countriesFromMSsql = sqlCountriesRepo.GetAll().ToList();
            foreach (var countryFromMSsql in countriesFromMSsql.ToList())
            {
                var country = new Country()
                {
                    Name = countryFromMSsql.Name
                };
                mySqlCountriesRepo.Add(country);
                mySqlCountriesRepo.SaveChanges();
            }
        }

        private static void AddTaxToGirl(string firstname, string lastname, int tax)
        {
            var girlRepo = new GenericRepository<Girl>(new GirlsAgencyContext());
            var girl = girlRepo.Search(g => g.FirstName == firstname && g.LastName == lastname).FirstOrDefault();

            if (girl == null)
            {
                throw new ApplicationException("Girl does not exists/found");
            }

            var girlTaxes = new GirlsTaxesEntities();

            string girlFullName = girl.FirstName + " " + girl.LastName;

            var girlTax = GetAssignTax(girlFullName, girlTaxes);

            if (girlTax == null)
            {
                girlTaxes.GirlsTaxes.Add(new GirlsTax
                {
                    GirlName = girlFullName,
                    Tax = tax
                });
            }
            else
            {
                girlTax.Tax = tax;
            }

            girlTaxes.SaveChanges();
        }

        private static GirlsTax GetAssignTax(string fullName, GirlsTaxesEntities ctx)
        {
            return ctx.GirlsTaxes.FirstOrDefault(n => n.GirlName == fullName);
        }

        private static void printJSON(string p)
        {
            var repo = new GenericRepository<Girl>
                (new GirlsAgencyContext());
            switch (p)
            {
                // TODO finish this
                case "Girls":

                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    var entities = repo.GetAll().Select(g => new
                    {
                        FirstName = g.FirstName,
                        LastName = g.LastName,
                        BreastSize = ((BreastSizeEnum)g.BreastSizeId).ToString(),
                        City = g.City.Name,
                        Country = g.Country.Name,
                        HairColor = ((HairColorEnum)g.HairColorId).ToString(),
                        Customers = g.Customers.Select(c => c.FirstName + " " + c.LastName)

                    });
                    Console.WriteLine(jss.Serialize(entities));
                    break;
            }
        }
    }
}
