using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_DTO
{
    public partial class Buy_DTO
    {
        public short IdBuy { get; set; }
        public short CustomerId { get; set; }
        public DateTime? DateBuy { get; set; }
        public double AmountToPay { get; set; }
    }
}
