namespace GirlsAgency.Data
{
    using System.Data.Entity;
    using GirlsAgency.Model;
    using GirlsAgency.Repository.Contracts;

    public class GirlsAgencyContext : DbContext , IContext
    {
        public GirlsAgencyContext(): base("GirlsAgencyContext") { }

        public virtual IDbSet<Girl> Girls { get; set; }

        public virtual IDbSet<Customer> Customers { get; set; }
        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        
    }
}