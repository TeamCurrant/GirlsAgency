namespace GirlsAgency.Repository
{
    using System.Collections.Generic;
    using GirlsAgency.Model;
    using GirlsAgency.Repository.Contracts;

    public  class Requester
    {


        public Requester(IContext context)
        {
            this.DbContext = context;
        }


        public ICollection<IContext> Contexts { get; set; } 

        public virtual IContext DbContext { get; set; }


        public void ImportGirlsToDatabase(ICollection<Girl> girls)
        {
            // TODO exception handling models

            foreach (var girl in girls)
            {
                this.DbContext.Girls.Add(girl);
            }

            this.DbContext.SaveChanges();
        }
    }
}
