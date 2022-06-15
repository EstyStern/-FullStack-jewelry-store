using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_DTO
{
    public partial class Jewelry_DTO
    {
        public short JewelryId { get; set; }
        public string JewelryName { get; set; }
        public short CodeCategory { get; set; }
        public double JewelryPrice { get; set; }
        public string JewelryImage { get; set; }
        public int? UnitsInStock { get; set; }
        public string Material { get; set; }
    }
}
