using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GirlsAgency.Model
{
    using System;

    public class Order
    {

        public Order()
        {
        }

        public int Id { get; set; }
        
        public virtual int GirlId { get; set; }

        public virtual int CustomerId { get; set; }

        public int Duration { get; set; }

        public DateTime Date { get; set; }
    }
}
