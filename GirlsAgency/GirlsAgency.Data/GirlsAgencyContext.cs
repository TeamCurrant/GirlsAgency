namespace GirlsAgency.Data
{
    using System.Data.Entity;
    using Model;
    using Repository.Contracts;

    public class GirlsAgencyContext : DbContext , IContext
    {
        public GirlsAgencyContext(): base("GirlsAgencyContext") { }

        public virtual IDbSet<Girl> Girls { get; set; }

        public virtual IDbSet<Customer> Customers { get; set; }

        public virtual IDbSet<Order> Orders { get; set; }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        
    }
}