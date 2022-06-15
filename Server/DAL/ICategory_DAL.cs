using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL
{
    public interface ICategory_DAL
    {
        //שליפת רשימת קטגוריות
        public List<CategoryTbl> GetAllCategorys();
        //שליפת קטגוריה לפי קוד
        public CategoryTbl GetCategoryByCode(short Code);
        //הוספה לרשימת הקטגוריות
        string AddCategory(CategoryTbl c);
        //עדכון קטגוריה ברשימה
        public List<CategoryTbl> UpdateCategory(CategoryTbl c);
        //הסרת קטגוריה מהרשימה
        public CategoryTbl RemoveCategoryByCode(short Code);
    }
}
