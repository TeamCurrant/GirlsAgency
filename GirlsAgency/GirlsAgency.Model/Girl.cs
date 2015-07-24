using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GirlsAgency.Model
{
    public class Girl
    {
        private ICollection<Feature> features;
        private ICollection<Customer> customers;

        public Girl()
        {
            this.features = new HashSet<Feature>();
            this.customers = new HashSet<Customer>();
        }

        public int Id { get; set; }

        // [Index("IX_GirlsUnique", 1, IsUnique = true)]
        public string FirstName { get; set; }

        // [Index("IX_GirlsUnique", 2, IsUnique = true)]
        public string LastName { get; set; }

        // [Index("IX_GirlsUnique", 3, IsUnique = true)]
        public int Age { get; set; }

        public int BreastSizeId { get; set; }

        public int HairColorId { get; set; }

       // [ForeignKey("CityId")]
        public int CityId { get; set; }


        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        [ForeignKey("Country")]
        public int CountyId { get; set; }

        public decimal PricePerHour { get; set; }

        public virtual ICollection<Feature> Features
        {
            get { return this.features; }
            set { this.features = value; }
        }

        public virtual ICollection<Customer> Customers
        {
            get { return this.customers; }
            set { this.customers = value; }
        }
    }
}
