using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GirlsAgency.Data;
using GirlsAgency.Model;
using GirlsAgency.Repository.Contracts;
using GirlsAgencyOracle;
using GirlsAgencyOracle.Data;

namespace GirlsAgency.Repository
{
    public class RepositoryController : IRepository
    {
        // TODO try to remove oracle reference
        // TODO partial ?
        // TODO ImportClasses
        // TODO CRUD OPERATIONS

        private OracleContext oracleContext;

        private GirlsAgencyContext sqlServerContext;

        public Requester Requester{ get; set; }

        //takes the contexts from different servers
        public RepositoryController(OracleContext oracleContext, GirlsAgencyContext girlsAgencyContext)
        {

            //this.OracleContext = oracleContext;
            //this.SqlServerContext = girlsAgencyContext;
           // this.Requester = new Requester(new List<IContext>{oracleContext, girlsAgencyContext});
            this.Requester = new Requester(girlsAgencyContext);
        }


        public void Test(ICollection<Girl> girls )
        {
            this.Requester.ImportGirlsToDatabase(girls);
        }

        public OracleContext OracleContext
        {
            get
            {
                return this.oracleContext;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Oracle context cannot be null!");
                }

                this.oracleContext = value;
            }

        }

        public GirlsAgencyContext SqlServerContext
        {
            get
            {
                return this.sqlServerContext;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Sql server context cannot be null!");
                }

                this.sqlServerContext = value;
            }

        }

        public void ImportGirlsToDatabase(ICollection<Girl> girls)
        {
            // TODO exception handling models

            foreach (var girl in girls)
            {
                this.SqlServerContext.Girls.Add(girl);
                this.OracleContext.Girls.Add(girl);
            }

            this.SqlServerContext.SaveChanges();
            this.OracleContext.SaveChanges();
        }

        public ICollection<Girl> GetGirslFromDatabase()
        {
            throw new NotImplementedException();
        }
    }
}
