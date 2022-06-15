using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class CustomersTbl
    {
        public CustomersTbl()
        {
            BuyTbls = new HashSet<BuyTbl>();
        }

        public short CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerPassword { get; set; }
        public string CreditNumber { get; set; }

        public virtual ICollection<BuyTbl> BuyTbls { get; set; }
    }
}
