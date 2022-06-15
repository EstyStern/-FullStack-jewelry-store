using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;

namespace DAL
{
    public class Category_DAL : ICategory_DAL
    {
        //DB-מופע מסוג ה
        Jewelry_dbContext _db;

        //constarctor
        //מנהל התלויות יזריק מסד נתונים
        public Category_DAL(Jewelry_dbContext _mydb)
        {
            _db = _mydb;
        }

        //הוספה לרשימת הקטגוריות
        public string AddCategory(CategoryTbl c)
        {
            try
            {
                _db.CategoryTbls.Add(c);
                _db.SaveChanges();
                return "Succeeded!";
            }
            catch
            {
                return "Fails";
            }
            
        }

        //שליפת רשימת קטגוריות
        public List<CategoryTbl> GetAllCategorys()
        {
            return _db.CategoryTbls.ToList();
        }

        //שליפת קטגוריה לפי קוד
        public CategoryTbl GetCategoryByCode(short Code)
        {
            var CategorygetByCode = _db.CategoryTbls.FirstOrDefault(p => p.CodeCategory == Code);
            if (CategorygetByCode != null)
            {
                return CategorygetByCode;
            }
            return null;
        }

        //הסרת קטגוריה מהרשימה
        public CategoryTbl RemoveCategoryByCode(short Code)
        {
            var CategoryToRemove = _db.CategoryTbls.FirstOrDefault(p => p.CodeCategory == Code);
            _db.CategoryTbls.Remove(CategoryToRemove);
            _db.SaveChanges();
            return CategoryToRemove;
        }

        //עדכון קטגוריה ברשימה
        public List<CategoryTbl> UpdateCategory(CategoryTbl c)
        {
            var CategoryToEdit = _db.CategoryTbls.FirstOrDefault(p => p.CodeCategory == c.CodeCategory);
            if (CategoryToEdit != null)
            {
                CategoryToEdit.CodeCategory = c.CodeCategory;
                CategoryToEdit.NameCategory = c.NameCategory;
                _db.SaveChanges();
                return _db.CategoryTbls.ToList();
            }
            return null;
        }
    }
}
