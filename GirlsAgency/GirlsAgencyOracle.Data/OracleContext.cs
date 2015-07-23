using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GirlsAgency.Model;
using GirlsAgency.Repository.Contracts;
using GirlsAgencyOracle.Data.Migrations;

namespace GirlsAgencyOracle.Data
{
    public class OracleContext : DbContext, IContext
    {
        public OracleContext()
            : base("OracleDbContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<OracleContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OracleContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.HasDefaultSchema("KUR");
            base.OnModelCreating(modelBuilder);
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
    }
}