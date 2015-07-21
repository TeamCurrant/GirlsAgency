namespace GirlsAgency.Model
{
    using System.Collections.Generic;

    public class City
    {
        private ICollection<Girl> girls;
        private ICollection<Customer> customers;
 
        public City()
        {
            this.girls = new HashSet<Girl>();
            this.customers = new HashSet<Customer>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

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
    }
}