using System.Data.Entity.Migrations;
using System.Collections.Generic;
using System.Linq;
using GirlsAgency.Data;
using GirlsAgency.Model;
using GirlsAgency.Model.Enums;
using System.Data;
using System;

namespace GirlsAgency.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GirlsAgencyContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "GirlsAgency.Data.GirlsAgencyContext";
        }

        protected override void Seed(GirlsAgencyContext context)
        {
            SeedCoutries(context);
            SeedCities(context);
            SeedCustomers(context);
            SeedGirls(context);
            SeedOrders(context);
        }

        private static void SeedOrders(GirlsAgencyContext context)
        {
            if (context.Orders.Any())
            {
                return;
            }

            var order1 = new Order
            {
                GirlId = 1,
                CustomerId = 1,
                Duration = 4,
                Date = new DateTime(2015, 5, 2)
            };

            var order2 = new Order
            {
                GirlId = 2,
                CustomerId = 2,
                Duration = 2,
                Date = new DateTime(2015, 7, 20)
            };

            var order3 = new Order
            {
                GirlId = 3,
                CustomerId = 3,
                Duration = 1,
                Date = new DateTime(2015, 7, 25)
            };


            var order4 = new Order
            {
                GirlId = 1,
                CustomerId = 2,
                Duration = 4,
                Date = new DateTime(2015, 7, 28)
            };

            var order5 = new Order
            {
                GirlId = 4,
                CustomerId = 4,
                Duration = 4,
                Date = new DateTime(2015, 7, 28)
            };


            var order6 = new Order
            {
                GirlId = 5,
                CustomerId = 2,
                Duration = 2,
                Date = new DateTime(2015, 8, 1)
            };

            context.Orders.Add(order1);
            context.Orders.Add(order2);
            context.Orders.Add(order3);
            context.Orders.Add(order4);
            context.Orders.Add(order5);
            context.Orders.Add(order6);

            context.SaveChanges();
        }

        private static void SeedGirls(GirlsAgencyContext context)
        {
            if (context.Girls.Any())
            {
                return;
            }

            var minka = new Girl()
            {
                FirstName = "Minka",
                LastName = "Svirchoka",
                Age = 18,
                BreastSizeId = (int)BreastSizeEnum.Normal,
                HairColorId = (int)HairColorEnum.Blonde,
                PricePerHour = 80.0M,
                Features = new HashSet<Feature>
           {
               new Feature {Name = GirlsFeaturesEnum.Felatio.ToString()},
               new Feature {Name = GirlsFeaturesEnum.DoggyStyle.ToString()}
           },
                CityId = 1,
                CountyId = 1
            };

            var penka = new Girl()
            {
                FirstName = "Penka",
                LastName = "For All",
                Age = 18,
                BreastSizeId = (int)BreastSizeEnum.Huge,
                HairColorId = (int)HairColorEnum.Black,
                PricePerHour = 100.0M,
                Features = new HashSet<Feature>
           {
               new Feature {Name = GirlsFeaturesEnum.Felatio.ToString()},
               new Feature {Name = GirlsFeaturesEnum.DoggyStyle.ToString()},
               new Feature {Name = GirlsFeaturesEnum.Standart.ToString()}
           },
                CityId = 2,
                CountyId = 1
            };

            var orchid = new Girl()
            {
                FirstName = "Orhideia",
                LastName = "Bitcheva",
                Age = 19,
                BreastSizeId = (int)BreastSizeEnum.Tiny,
                HairColorId = (int)HairColorEnum.Brown,
                PricePerHour = 90.0M,
                Features = new HashSet<Feature>
           {
               new Feature {Name = GirlsFeaturesEnum.Felatio.ToString()},
               new Feature {Name = GirlsFeaturesEnum.Standart.ToString()}
           },
                CityId = 3,
                CountyId = 1
            };


            var dirty = new Girl()
            {
                FirstName = "Little",
                LastName = "Dirty",
                Age = 18,
                BreastSizeId = (int)BreastSizeEnum.Big,
                HairColorId = (int)HairColorEnum.Red,
                PricePerHour = 200.0M,
                Features = new HashSet<Feature>
           {
               new Feature {Name = GirlsFeaturesEnum.Felatio.ToString()},
               new Feature {Name = GirlsFeaturesEnum.All.ToString()},
               new Feature {Name = GirlsFeaturesEnum.DoggyStyle.ToString()}
           },
                CityId = 4,
                CountyId = 1
            };

            var sosi = new Girl()
            {
                FirstName = "Soska",
                LastName = "Soskova",
                Age = 18,
                BreastSizeId = (int)BreastSizeEnum.NotDefined,
                HairColorId = (int)HairColorEnum.White,
                PricePerHour = 50.0M,
                Features = new HashSet<Feature>
           {
               new Feature {Name = GirlsFeaturesEnum.Felatio.ToString()},
               new Feature {Name = GirlsFeaturesEnum.DoggyStyle.ToString()}
           },
                CityId = 5,
                CountyId = 1
            };

            context.Girls.Add(minka);
            context.Girls.Add(penka);
            context.Girls.Add(orchid);
            context.Girls.Add(dirty);
            context.Girls.Add(sosi);

            context.SaveChanges();
        }

        private static void SeedCustomers(GirlsAgencyContext context)
        {
            if (context.Customers.Any())
            {
                return;
            }

            var pesh = new Customer()
            {
                FirstName = "Pesho",
                LastName = "The Crazy",
                CityId = 2,
                CountryId = 1
            };

            var gosh = new Customer()
            {
                FirstName = "Gosh",
                LastName = "The Nigga",
                CityId = 1,
                CountryId = 1
            };

            var sash = new Customer()
            {
                FirstName = "Sasha",
                LastName = "Bliad",
                CityId = 5,
                CountryId = 2
            };

            var misho = new Customer()
            {
                FirstName = "Mihail",
                LastName = "Rapper",
                CityId = 3,
                CountryId = 1
            };

            var sisi = new Customer()
            {
                FirstName = "Sashka",
                LastName = "Slivova",
                CityId = 1,
                CountryId = 1
            };

            context.Customers.Add(pesh);
            context.Customers.Add(gosh);
            context.Customers.Add(sash);
            context.Customers.Add(misho);
            context.Customers.Add(sisi);

            context.SaveChanges();
        }

        private static void SeedCities(GirlsAgencyContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

            var sofia = new City() { Name = "Sofia", CountryId = 1 };
            var staraZagora = new City() { Name = "Stara Zagora", CountryId = 1 };
            var ruse = new City() { Name = "Ruse", CountryId = 1 };
            var vt = new City() { Name = "Veliko Tyrnovo", CountryId = 1 };
            var moscow = new City() { Name = "Moscow", CountryId = 2 };

            context.Cities.Add(sofia);
            context.Cities.Add(staraZagora);
            context.Cities.Add(ruse);
            context.Cities.Add(vt);
            context.Cities.Add(moscow);

            context.SaveChanges();
        }

        private static void SeedCoutries(GirlsAgencyContext context)
        {
            if (context.Countries.Any())
            {
                return;
            }

            var bul = new Country() { Name = "Bulgaria" };
            var rus = new Country() { Name = "Russia" };
            var ukr = new Country() { Name = "Ukraine" };
            var mol = new Country() { Name = "Moldova" };
            var jam = new Country() { Name = "Jamaika" };

            context.Countries.Add(bul);
            context.Countries.Add(rus);
            context.Countries.Add(ukr);
            context.Countries.Add(mol);
            context.Countries.Add(jam);

            context.SaveChanges();
        }
    }
}
