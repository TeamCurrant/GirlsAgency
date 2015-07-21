using GirlsAgency.Repository.Contracts;

namespace GirlsAgency.Data
{
    using Model;
    using System.Data.Entity;

    public class GirlsAgencyContext : DbContext , IContext
    {
        public GirlsAgencyContext(): base("GirlsAgencyContext") { }

        public virtual DbSet<Girl> Girls { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

    }
}