using System;
using DAL.Models;

namespace Entities_DTO
{
    public class Auto:AutoMapper.Profile
    {
        public Auto()
        {
            //המרה
            //DTO מיפוי בין האובייקטים שיצרתי ב
            //DBלבין ה
            CreateMap<CategoryTbl, Category_DTO>();
            CreateMap<Category_DTO, CategoryTbl>();

            CreateMap<CustomersTbl, Customers_DTO>();
            CreateMap<Customers_DTO, CustomersTbl>();

            CreateMap<JewelryTbl, Jewelry_DTO>();
            CreateMap<Jewelry_DTO, JewelryTbl>();

            CreateMap<BuyTbl, Buy_DTO>();
            CreateMap<Buy_DTO, BuyTbl>();

            CreateMap<BuyDetailsTbl, BuyDetails_DTO>();
            CreateMap<BuyDetails_DTO, BuyDetailsTbl>();
        }
    }
}
