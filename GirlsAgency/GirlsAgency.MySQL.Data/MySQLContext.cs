namespace GirlsAgency.MySQL.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using GirlsAgency.Model;

    public class MySQLContext : DbContext
    {
        // Your context has been configured to use a 'MySQLContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GirlsAgency.MySQL.Data.MySQLContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MySQLContext' 
        // connection string in the application configuration file.
        public MySQLContext()
            : base("name=MySQLContext1")
        {
        }

        public DbSet<BreastSize> BreastSizes { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Girl> Girls { get; set; }

        public DbSet<HairColor> HairColors { get; set; }

        public DbSet<Order> Orders { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}