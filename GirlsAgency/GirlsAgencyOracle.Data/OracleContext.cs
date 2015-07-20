using GirlsAgency.Model;
using GirlsAgencyOracle.Data.Migrations;

namespace GirlsAgencyOracle.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OracleContext : DbContext
    {
        // Your context has been configured to use a 'OracleContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GirlsAgencyOracle.Data.OracleContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'OracleContext' 
        // connection string in the application configuration file.
        public OracleContext()
            : base("OracleDbContext")
        {
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<OracleContext, Configuration>());
            Database.SetInitializer(new DropCreateDatabaseAlways<OracleContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("KUR");
            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Girl> Girls { get; set; }

        //public virtual DbSet<BreastSize> BreastSizes { get; set; }

        //public virtual DbSet<Country> Countries { get; set; }

        //public virtual DbSet<Feature> Features { get; set; }

        //public virtual DbSet<HairColor> HairColors { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        //public virtual DbSet<City> Cities { get; set; }

       

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