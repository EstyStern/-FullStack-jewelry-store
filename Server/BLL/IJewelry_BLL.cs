using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entities_DTO;
namespace BLL
{
    public interface IJewelry_BLL
    {
        //שליפת רשימת תכשיטים
        public List<Jewelry_DTO> GetAllJewelry();
        //שליפת תכשיט לפי קוד
        public Jewelry_DTO getJewelryById(short id);
        //הוספה לרשימת התכשיטים
        string AddJewelry(Jewelry_DTO J);
        //עדכון תכשיט ברשימה לפי קוד
        public string UpdateJewelry(Jewelry_DTO j);
        //הסרת תכשיט מהרשימה
        public Jewelry_DTO RemoveJewelryById(short id);
        //שליפת תכשיטים לפי קטגוריה מבוקשת
        public List<Jewelry_DTO> getJewelrysByCodeCategory(short CodeCategory);
    }
}
