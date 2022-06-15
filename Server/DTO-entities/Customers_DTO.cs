using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_DTO
{
    public partial class Customers_DTO
    {
        public short CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerPassword { get; set; }
        public string CreditNumber { get; set; }
    }
}
