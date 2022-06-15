using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

 namespace DAL
{
    public interface IDetailsShoppingDAL
    {
        List<BuyDetailsTbl> GetAllDetailsShopping();

        BuyDetailsTbl GetDetailsShoppingById(int id);



        List<BuyDetailsTbl> UpdateDetailsShopping(BuyDetailsTbl ds);

        List<BuyDetailsTbl> AddDetailsShopping(BuyDetailsTbl ds);

        List<BuyDetailsTbl> DeleateDetailsShopping(int id);
    }
}
