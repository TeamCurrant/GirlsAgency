namespace GirlsAgency.Repository.Repositories
{

    using GirlsAgency.Model;
    using GirlsAgency.Repository.Contracts;
    
    /// <summary>
    /// Custom Customer Repository
    /// May contains custom methods
    /// </summary>

    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(IContext context) : base(context)
        {
        }
    }
}
