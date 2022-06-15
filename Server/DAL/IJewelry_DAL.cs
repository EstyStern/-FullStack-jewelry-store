using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IJewelry_DAL
    {
        //שליפת רשימת תכשיטים
        public List<JewelryTbl> GetAllJewelry();
        //שליפת תכשיט לפי קוד
        public JewelryTbl getJewelryById(short id);
        //הוספה לרשימת התכשיטים
        string AddJewelry(JewelryTbl J);
        
        //הסרת תכשיט מהרשימה
        public JewelryTbl RemoveJewelryById(short id);

        ////שליפת תכשיטים לפי קטגוריה מבוקשת
        //public List<JewelryTbl> getJewelrysByCodeCategory(short CodeCategory);

        ////עדכון תכשיט ברשימה לפי קוד
        public string UpdateJewelry(JewelryTbl J);
    }
}
