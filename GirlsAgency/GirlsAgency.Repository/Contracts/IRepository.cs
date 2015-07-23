using System.Collections.Generic;
using GirlsAgency.Model;

namespace GirlsAgency.Repository.Contracts
{
    public interface IRepository
    {
        void ImportGirlsToDatabase(ICollection<Girl> girls);

        ICollection<Girl> GetGirslFromDatabase();

    }
}
