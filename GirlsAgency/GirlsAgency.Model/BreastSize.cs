namespace GirlsAgency.Model
{
    using Enums;
    using System.Collections.Generic;

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
