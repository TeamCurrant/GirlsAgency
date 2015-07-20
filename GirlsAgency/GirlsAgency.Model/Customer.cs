namespace GirlsAgency.Model
{
    using System.Collections.Generic;

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

        public int CityId { get; set; }

        public virtual ICollection<Girl> Girls
        {
            get { return this.girls; }
            set { this.girls = value; }
        }
    }
}
