using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_DTO
{
    public partial class BuyDetails_DTO
    {
        public short IdBuyDetails { get; set; }
        public short IdBuy { get; set; }
        public short JewelryId { get; set; }
        public int? Qty { get; set; }
    }
}
