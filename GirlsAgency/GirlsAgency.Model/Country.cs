using System.Collections.Generic;

namespace GirlsAgency.Model
{
    public class Country
    {
        private ICollection<City> cities;
        private ICollection<Girl> girls;

        public Country()
        {
            this.cities = new HashSet<City>();
            this.girls = new HashSet<Girl>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }

        //public virtual ICollection<Girl> Girls
        //{
        //    get { return this.girls; }
        //    set { this.girls = value; }
        //}
    }
}
