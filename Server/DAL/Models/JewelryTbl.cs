using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class JewelryTbl
    {
        public JewelryTbl()
        {
            BuyDetailsTbls = new HashSet<BuyDetailsTbl>();
        }

        public short JewelryId { get; set; }
        public string JewelryName { get; set; }
        public short CodeCategory { get; set; }
        public double JewelryPrice { get; set; }
        public string JewelryImage { get; set; }
        public int? UnitsInStock { get; set; }
        public string Material { get; set; }

        public virtual CategoryTbl CodeCategoryNavigation { get; set; }
        public virtual ICollection<BuyDetailsTbl> BuyDetailsTbls { get; set; }
    }
}
