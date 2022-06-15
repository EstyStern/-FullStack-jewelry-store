using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class CategoryTbl
    {
        public CategoryTbl()
        {
            JewelryTbls = new HashSet<JewelryTbl>();
        }

        public short CodeCategory { get; set; }
        public string NameCategory { get; set; }

        public virtual ICollection<JewelryTbl> JewelryTbls { get; set; }
    }
}
