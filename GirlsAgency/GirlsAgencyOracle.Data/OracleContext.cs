namespace GirlsAgencyOracle.Data
{
    using System.Data.Entity;
    using GirlsAgency.Model;
    using GirlsAgency.Repository.Contracts;


    public class OracleContext : DbContext, IContext
    {
        public OracleContext()
            : base("OracleDbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<OracleContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("KUR");
            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<Girl> Girls { get; set; }

        public virtual IDbSet<Customer> Customers { get; set; }
      
        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}