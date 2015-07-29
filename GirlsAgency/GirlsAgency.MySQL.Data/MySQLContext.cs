using GirlsAgency.Repository.Contracts;

namespace GirlsAgency.MySQL.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using GirlsAgency.Model;
   // using GirlsAgency.Repository.Contracts;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using GirlsAgency.MySQL.Data.Migrations;

    public class MySQLContext : DbContext, IContext
    {
        // Your context has been configured to use a 'MySQLContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GirlsAgency.MySQL.Data.MySQLContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MySQLContext' 
        // connection string in the application configuration file.
        public MySQLContext()
            : base("name=MySQLContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MySQLContext, Configuration>());
        }

        public virtual IDbSet<BreastSize> BreastSizes { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Customer> Customers { get; set; }

        public virtual IDbSet<Feature> Features { get; set; }

        public virtual IDbSet<Girl> Girls { get; set; }

        public virtual IDbSet<HairColor> HairColors { get; set; }

        public virtual IDbSet<Order> Orders { get; set; }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //   // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //}
    }
}