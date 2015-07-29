using System.Data.Entity.ModelConfiguration.Conventions;
using GirlsAgency.Model;
using GirlsAgency.Repository.Contracts;

namespace GirlAgencyMySql.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MySql : DbContext, IContext
    {
        // Your context has been configured to use a 'MySql' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GirlAgencyMySql.Data.MySql' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MySql' 
        // connection string in the application configuration file.
        public MySql()
            : base("name=MySql")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public IDbSet<Girl> Girls { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<City> Cities { get; set; }
        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}