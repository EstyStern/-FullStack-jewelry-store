using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL
{
    public interface IShoppingDAL
    {
        List<BuyTbl> GetAllShopping();

        BuyTbl GetShoppingById(int id);

        List<BuyTbl> UpdateShopping(BuyTbl sp);

        List<BuyTbl> AddShopping(BuyTbl sp);

        List<BuyTbl> DeleateShopping(int id);
    }
}
