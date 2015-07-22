namespace GirlsAgency.Repository.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using GirlsAgency.Model;

    public interface IContext
    {
        IDbSet<Girl> Girls { get; set; }

        IDbSet<Customer> Customers { get; set; }

        int SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
