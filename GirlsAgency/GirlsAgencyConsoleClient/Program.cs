using System;
using System.Linq;
using GirlsAgencyOracle.Data;

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
         //   var girl = new Girl()
           
            Console.WriteLine(context.Customers.Count());
            //Console.WriteLine(girlsCount);
        }
    }
}
