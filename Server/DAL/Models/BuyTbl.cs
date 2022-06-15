using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class BuyTbl
    {
        public BuyTbl()
        {
            BuyDetailsTbls = new HashSet<BuyDetailsTbl>();
        }

        public short IdBuy { get; set; }
        public short CustomerId { get; set; }
        public DateTime? DateBuy { get; set; }

        //public float AmountToPay { get; set; }
        public double AmountToPay { get; set; }

        public virtual CustomersTbl Customer { get; set; }
        public virtual ICollection<BuyDetailsTbl> BuyDetailsTbls { get; set; }
    }
}
