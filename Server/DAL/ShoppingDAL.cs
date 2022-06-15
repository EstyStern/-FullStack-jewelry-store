using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Linq;


namespace DAL
{
    public class ShoppingDAL : IShoppingDAL

    {
        //יצירת משתנה מסוג הDB
        Jewelry_dbContext _DB;
        public ShoppingDAL(Jewelry_dbContext DB)
        {
            _DB = DB;
        }
        //הוספה לטבלה
        public List<BuyTbl> AddShopping(BuyTbl sp)
        {
            _DB.BuyTbls.Add(sp);
            _DB.SaveChanges();
            return _DB.BuyTbls.ToList();

        }
        //מחיקה מהטבלה
        public List<BuyTbl> DeleateShopping(int id)
        {
            _DB.BuyTbls.Remove(_DB.BuyTbls.FirstOrDefault(p => p.IdBuy == id));
            _DB.SaveChanges();
            return _DB.BuyTbls.ToList();
        }
        //קבלת כל הטבלה
        public List<BuyTbl> GetAllShopping()
        {
            return _DB.BuyTbls.ToList();
        }
        //קבלת רשומה לפי מספר מטבלה
        public BuyTbl GetShoppingById(int id)
        {
            var sp = _DB.BuyTbls.FirstOrDefault(p => p.IdBuy == id);
            if (sp != null)
                return sp;
            return null;
        }
        //עדכון רשומה בטבלה
        public List<BuyTbl> UpdateShopping(BuyTbl sp)
        {
            var spToEdit = _DB.BuyTbls.FirstOrDefault(p => p.IdBuy == sp.IdBuy);
            if (spToEdit != null)
            {
                spToEdit.IdBuy = sp.IdBuy;
                spToEdit.CustomerId = sp.CustomerId;
                spToEdit.DateBuy = sp.DateBuy;
                spToEdit.AmountToPay = sp.AmountToPay;
                _DB.SaveChanges();
            }

            return _DB.BuyTbls.ToList();
        }
    }
}
