using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using GirlsAgency.Model;

namespace GirlsAgency.Repository.Contracts
{
    public interface IContext
    {
        IDbSet<Girl> Girls { get; set; }

        IDbSet<Customer> Customers { get; set; }

        int SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
