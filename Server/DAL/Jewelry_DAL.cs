using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Jewelry_DAL : IJewelry_DAL
    {
        //DB-מופע מסוג ה
        Jewelry_dbContext _db;

        //constarctor
        //מנהל התלויות יזריק מסד נתונים
        public Jewelry_DAL(Jewelry_dbContext _mydb)
        {
            _db = _mydb;
        }

        //הוספה לרשימת התכשיטים
        public string AddJewelry(JewelryTbl J)
        {
            try
            {
                _db.JewelryTbls.Add(J);
                _db.SaveChanges();
                return "Succeeded!";
            }
            catch
            {
                return "Fails!";
            }

        }

        //שליפת רשימת תכשיטים
        public List<JewelryTbl> GetAllJewelry()
        {
            return _db.JewelryTbls.ToList();
        }

        //שליפת תכשיט לפי קוד
        public JewelryTbl getJewelryById(short id)
        {
            var JewelrygetById = _db.JewelryTbls.FirstOrDefault(p => p.JewelryId == id);
            if (JewelrygetById != null)
            {
                return JewelrygetById;
            }
            return null;
        }

        //הסרת תכשיט מהרשימה
        public JewelryTbl RemoveJewelryById(short id)
        {
            var JewelryToRemove = _db.JewelryTbls.FirstOrDefault(p => p.JewelryId == id);
            _db.JewelryTbls.Remove(JewelryToRemove);
            _db.SaveChanges();
            return JewelryToRemove;
        }

        //עדכון תכשיט ברשימה לפי קוד----??
        public string UpdateJewelry(JewelryTbl J)
        {
            try
            {
                var Myjewelry = getJewelryById(J.JewelryId);
                if (Myjewelry != null)
                {
                    Myjewelry.JewelryId = J.JewelryId;
                    Myjewelry.JewelryName = J.JewelryName;
                    Myjewelry.CodeCategory = J.CodeCategory;
                    Myjewelry.JewelryPrice = J.JewelryPrice;
                    Myjewelry.JewelryImage = J.JewelryImage;
                    Myjewelry.UnitsInStock = J.UnitsInStock;
                    Myjewelry.Material = J.Material;
                    _db.SaveChanges();
                    return "Succeeded!!!";
                }
                return "faild";
            }
            catch
            {
                return "faild";
            }

            //}

            ////שליפת תכשיטים לפי קטגוריה מבוקשת----????
            //public List<JewelryTbl> getJewelrysByCodeCategory(short CodeCategory)
            //{
            //    List<JewelryTbl> myJewelrysByCodeCategory = (List<JewelryTbl>)_db.JewelryTbls.Where(p => p.CodeCategory == CodeCategory);
            //    if (myJewelrysByCodeCategory != null)
            //    {
            //    return myJewelrysByCodeCategory;
            //    }
            //    return null;
            //}
        }
    }
}
