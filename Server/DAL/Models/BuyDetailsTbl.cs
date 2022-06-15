using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class BuyDetailsTbl
    {
        public short IdBuyDetails { get; set; }
        public short IdBuy { get; set; }
        public short JewelryId { get; set; }
        public int? Qty { get; set; }

        public virtual BuyTbl IdBuyNavigation { get; set; }
        public virtual JewelryTbl Jewelry { get; set; }
    }
}
