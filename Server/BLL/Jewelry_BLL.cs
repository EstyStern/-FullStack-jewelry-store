using AutoMapper;
using DAL;
using Entities_DTO;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Linq;

namespace BLL
{
    public class Jewelry_BLL : IJewelry_BLL
    {
        IJewelry_DAL _Jewelry_DAL;
        IMapper _imapper;

        public Jewelry_BLL(IJewelry_DAL JewelryDAL)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Auto>();

            });
            _imapper = config.CreateMapper();
            _Jewelry_DAL = JewelryDAL;
        }

        //הוספה לרשימת התכשיטים
        public string AddJewelry(Jewelry_DTO J)
        {
            JewelryTbl JewelryMap = _imapper.Map<Jewelry_DTO, JewelryTbl>(J);
            try
            {
                _Jewelry_DAL.AddJewelry(JewelryMap);
                return "Succeeded!";
            }
            catch
            {
                return "Fails!";
            }
        }

        //הסרת תכשיט מהרשימה
        public Jewelry_DTO RemoveJewelryById(short CodeCategory)
        {
            JewelryTbl J = _Jewelry_DAL.RemoveJewelryById(CodeCategory);
            return _imapper.Map<JewelryTbl, Jewelry_DTO>(J);
        }

        //שליפת תכשיט לפי קוד
        public Jewelry_DTO getJewelryById(short id)
        {
            JewelryTbl j = _Jewelry_DAL.getJewelryById(id);
            return _imapper.Map<JewelryTbl, Jewelry_DTO>(j);
        }

        //שליפת רשימת תכשיטים
        public List<Jewelry_DTO> GetAllJewelry()
        {
            List<JewelryTbl> J = _Jewelry_DAL.GetAllJewelry();
            return _imapper.Map<List<JewelryTbl>, List<Jewelry_DTO>>(J);
        }


        
        //שליפת תכשיטים לפי קטגוריה מבוקשת
        public List<Jewelry_DTO> getJewelrysByCodeCategory(short CodeCategory)
        {
            List<JewelryTbl> myListALL = _Jewelry_DAL.GetAllJewelry();
            List<JewelryTbl> ListMap = myListALL.Where(p => p.CodeCategory == CodeCategory).ToList();
            return _imapper.Map<List<JewelryTbl>, List<Jewelry_DTO>>(ListMap);
        }

        //public string UpdateProduct(ProductDto p)
        //{
        //    Product prodToMap = _impper.Map<ProductDto, Product>(p);
        //    return _prodDal.UpdateProduct(prodToMap);
        //}
        public string UpdateJewelry(Jewelry_DTO j)
        {
            JewelryTbl jToMap = _imapper.Map<Jewelry_DTO, JewelryTbl>(j);
            return _Jewelry_DAL.UpdateJewelry(jToMap);


        }


        //Kategory KategoryForUpdate = _imapper.Map<KategoryDto, Kategory>(k);
        //    return _kategoryDal.UpdateKategory(KategoryForUpdate);
        //עדכון תכשיט ברשימה לפי קוד
        //public List<Jewelry_DTO> UpdateJewelry(short id )
        //{
        //    List<JewelryTbl> ListAll = _Jewelry_DAL.GetAllJewelry();
        //    List<JewelryTbl> ListMap = ListAll.Where(p => p.JewelryId == id).ToList();
        //    return _imapper.Map<List<JewelryTbl>, List<Jewelry_DTO>>(ListMap);


        //}
    }
}
