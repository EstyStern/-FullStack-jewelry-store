using System;
using System.Collections.Generic;
using System.Text;
using Entities_DTO;

namespace BLL
{
    public interface ICategory_BLL
    {
        //שליפת רשימת קטגוריות
        public List<Category_DTO> GetAllCategorys();
        //שליפת קטגוריה לפי קוד
        public Category_DTO GetCategoryByCode(short Code);
        //הוספה לרשימת הקטגוריות
        string AddCategory(Category_DTO c);
        //עדכון קטגוריה ברשימה
        public List<Category_DTO> UpdateCategory(Category_DTO c);
        //הסרת קטגוריה מהרשימה
        public Category_DTO RemoveCategoryByCode(short Code);
    }
}
