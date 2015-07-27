namespace GirlsAgency.MySQL.Data.Migrations
{

    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MySql.Data.Entity; 

    internal sealed class Configuration : DbMigrationsConfiguration<GirlsAgency.MySQL.Data.MySQLContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
        }

        protected override void Seed(GirlsAgency.MySQL.Data.MySQLContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
