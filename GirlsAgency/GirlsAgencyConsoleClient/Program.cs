namespace GirlsAgencyConsoleClient
{
    using System.Collections.Generic;
    using GirlsAgency.Model;
    using GirlsAgency.Model.Enums;

    using GirlsAgency.Data;

    class Program
    {
        static void Main()
        {
            var context = new GirlsAgencyContext();
            var girl = new Girl()
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
                }
            };




            context.Girls.Add(girl);
            context.SaveChanges();
            //Console.WriteLine(girlsCount);
        }
    }
}
