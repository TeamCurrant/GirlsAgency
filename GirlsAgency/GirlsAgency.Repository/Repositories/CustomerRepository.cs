using GirlsAgency.Model;
using GirlsAgency.Repository.Contracts;

namespace GirlsAgency.Repository.Repositories
{
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
