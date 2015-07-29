using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GirlsAgency.Model
{
    public class Customer
    {
        private ICollection<Girl> girls;

        public Customer()
        {
            this.girls = new HashSet<Girl>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public int CountryId { get; set; }

        // [ForeignKey("CityId")]

        //virtual
        public  int CityId { get; set; }

        public virtual ICollection<Girl> Girls
        {
            get { return this.girls; }
            set { this.girls = value; }
        }
    }
}
