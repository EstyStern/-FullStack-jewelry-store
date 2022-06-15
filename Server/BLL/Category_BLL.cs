using System.Collections.Generic;
using AutoMapper;
using DAL;
using DAL.Models;
using Entities_DTO;

namespace BLL
{
    public class Category_BLL : ICategory_BLL
    {
        ICategory_DAL _Category_DAL;
        IMapper _imapper;

        public Category_BLL(ICategory_DAL categoryDAL)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Auto>();

            });
            _imapper = config.CreateMapper();
            _Category_DAL = categoryDAL;
        }

        //הוספה לרשימת הקטגוריות
        public string AddCategory(Category_DTO c)
        {
            CategoryTbl categoryMap = _imapper.Map<Category_DTO, CategoryTbl>(c);
            try
            {
                _Category_DAL.AddCategory(categoryMap);
                return "Succeeded!";
            }
            catch
            {
                return "Fails!";
            }
        }



        //שליפת קטגוריה לפי קוד
        public Category_DTO GetCategoryByCode(short Code)
        {
            CategoryTbl c = _Category_DAL.GetCategoryByCode(Code);
            if (c != null)
            {
                return _imapper.Map<CategoryTbl, Category_DTO>(c);
            }
            return null;
        }

        //הסרת קטגוריה מהרשימה
        public Category_DTO RemoveCategoryByCode(short Code)
        {
            CategoryTbl c = _Category_DAL.RemoveCategoryByCode(Code);
            return _imapper.Map<CategoryTbl, Category_DTO>(c);
        }

        //שליפת רשימת קטגוריות
        public List<Category_DTO> GetAllCategorys()
        {
            List<CategoryTbl> c = _Category_DAL.GetAllCategorys();

            return _imapper.Map<List<CategoryTbl>, List<Category_DTO>>(c);
        }

        //עדכון קטגוריה ברשימה--??
        public List<Category_DTO> UpdateCategory(Category_DTO c)
        {
            CategoryTbl cMap = _imapper.Map<Category_DTO, CategoryTbl>(c);
            List<CategoryTbl> c2 = _Category_DAL.UpdateCategory(cMap);
            return _imapper.Map<List<CategoryTbl>, List<Category_DTO>>(c2);
        }
    }
}
