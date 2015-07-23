using System.Collections.Generic;

namespace GirlsAgency.Model
{
    using System;

    public class Order
    {
        private IEnumerable<Girl> girls;

        public Order()
        {
            this.girls = new HashSet<Girl>();
        }

        public int Id { get; set; }

        public int GirlId { get; set; }

        public int CustomerId { get; set; }

        public int Duration { get; set; }

        public DateTime Date { get; set; }

        public virtual IEnumerable<Girl> Girls
        {
            get { return this.girls; }
            set { this.girls = value; }
        } 
    }
}
