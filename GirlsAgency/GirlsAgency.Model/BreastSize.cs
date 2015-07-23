using System.Collections.Generic;
using GirlsAgency.Model.Enums;

namespace GirlsAgency.Model
{
    public class BreastSize
    {
        private ICollection<Girl> girls;

        public BreastSize()
        {
            this.girls = new HashSet<Girl>();
        }

        public int Id { get; set; }

        public BreastSizeEnum Size { get; set; }

        public virtual ICollection<Girl> Girls
        {
            get { return this.girls; }
            set { this.girls = value; }
        }
    }
}
