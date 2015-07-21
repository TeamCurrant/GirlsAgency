using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GirlsAgency.Model;

namespace GirlsAgency.Repository.Contracts
{
    public interface IContext
    {
        DbSet<Girl> Girls { get; set; }

        DbSet<Customer> Customers { get; set; }

        void SaveChanges();

    }


}
