using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GirlsAgency.Data.Migrations;
using GirlsAgency.Model;
using GirlsAgency.Repository.Contracts;

namespace GirlsAgency.Data
{
    public class GirlsAgencyContext : DbContext , IContext
    {
        public GirlsAgencyContext() : base("GirlsAgencyContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<GirlsAgencyContext, Configuration>());
            Database.SetInitializer(new DropCreateDatabaseAlways<GirlsAgencyContext>());
        }

        public virtual IDbSet<Girl> Girls { get; set; }

        public virtual IDbSet<Customer> Customers { get; set; }

        public virtual IDbSet<Order> Orders { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        
    }
}