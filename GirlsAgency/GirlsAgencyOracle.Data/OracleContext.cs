using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GirlsAgency.Model;
using GirlsAgency.Repository.Contracts;

namespace GirlsAgencyOracle.Data
{
    public class OracleContext : DbContext, IContext
    {
        public OracleContext()
            : base("OracleDbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<OracleContext>());
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