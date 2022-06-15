using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_DTO
{
    public class CartDTO
    {
        public short idCust { get; set; }
        public short idJewelry { get; set; }
        public string nameJewelry { get; set; }
        public decimal pricePerUnit { get; set; }
        public double totalPrice { get; set; }
        public int amount { get; set; }

        //public string img { get; set; }
        //public int CodeCategoty { get; set; }
    }
    
}
