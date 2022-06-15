using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Linq;

namespace DAL
{
    //יצירת משתנה מסוג הDB
    public class DetailsShoppingDAL : IDetailsShoppingDAL
    {
        Jewelry_dbContext _DB;
        public DetailsShoppingDAL(Jewelry_dbContext DB)
        {
            _DB = DB;
        }
        //הוספה לטבלה
        public List<BuyDetailsTbl> AddDetailsShopping(BuyDetailsTbl ds)
        {
            _DB.BuyDetailsTbls.Add(ds);
            _DB.SaveChanges();
            return _DB.BuyDetailsTbls.ToList();
        }
        //מחיקה מהטבלה
        public List<BuyDetailsTbl> DeleateDetailsShopping(int id)
        {
            _DB.BuyDetailsTbls.Remove(_DB.BuyDetailsTbls.FirstOrDefault(p => p.IdBuyDetails == id));
            _DB.SaveChanges();
            return _DB.BuyDetailsTbls.ToList();
        }
        //קבלת כל הטבלה
        public List<BuyDetailsTbl> GetAllDetailsShopping()
        {
            return _DB.BuyDetailsTbls.ToList();
        }
        //קבלת רשומה לפי מספר מטבלה
        public BuyDetailsTbl GetDetailsShoppingById(int id)
        {
            var ds = _DB.BuyDetailsTbls.FirstOrDefault(p => p.IdBuyDetails == id);
            if (ds != null)
                return ds;
            return null;
        }
        //עדכון רשומה בטבלה
        public List<BuyDetailsTbl> UpdateDetailsShopping(BuyDetailsTbl ds)
        {
            var dsToEdit = _DB.BuyDetailsTbls.FirstOrDefault(p => p.IdBuyDetails == ds.IdBuyDetails);
            if (dsToEdit != null)
            {
                dsToEdit.IdBuyDetails = ds.IdBuyDetails;
                dsToEdit.IdBuy = ds.IdBuy;
                dsToEdit.JewelryId = ds.JewelryId;
                dsToEdit.Qty = ds.Qty;
                
                _DB.SaveChanges();
            }
            return _DB.BuyDetailsTbls.ToList();
        }
    }
}
