using System.Collections.Generic;

namespace GirlsAgency.Model
{
    public class Feature
    {
        private ICollection<Girl> girls;

        public Feature()
        {
            this.girls = new HashSet<Girl>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Girl> Girls 
        {
            get { return this.girls; }
            set { this.girls = value; }
        }
    }
}
