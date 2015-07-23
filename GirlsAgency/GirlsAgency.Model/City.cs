using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GirlsAgency.Model
{
    public class City
    {
        private ICollection<Girl> girls;
        private ICollection<Customer> customers;
         
 
        public City()
        {
            this.girls = new HashSet<Girl>();
            this.customers = new HashSet<Customer>();
        }


        public Country Country { get; set; }


        [Key]
        public int CityId { get; set; }

        public string Name { get; set; }

      //  [ForeignKey("CountryId")]
        public int CountryId { get; set; }

        public virtual ICollection<Girl> Girls {
            get { return this.girls; }
            set { this.girls = value; }
        }

        public virtual ICollection<Customer> Customers
        {
            get { return this.customers; }
            set { this.customers = value; }
        }

        //public virtual ICollection<Girl> Girls
        //{
        //    get { return this.girls; }
        //    set { this.girls = value; }
        //}
    }
}