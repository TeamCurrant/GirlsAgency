using System;

namespace GirlsAgency.Model
{
    public class Order
    {

        public Order()
        {
        }

        public int Id { get; set; }
        
        public virtual Girl Girl { get; set; }

        public int GirlId { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public int Duration { get; set; }

        public DateTime Date { get; set; }
    }
}
