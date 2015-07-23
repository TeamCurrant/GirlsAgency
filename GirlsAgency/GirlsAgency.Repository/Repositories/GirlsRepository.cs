using GirlsAgency.Model;
using GirlsAgency.Repository.Contracts;

namespace GirlsAgency.Repository.Repositories
{
    /// <summary>
    /// Custom repo if someone needed
    /// May contains custom CRUD operations
    /// </summary>
    
    public class GirlsRepository : GenericRepository<Girl>
    {
        public GirlsRepository(IContext context) : base(context)
        {
        }
    }
}
